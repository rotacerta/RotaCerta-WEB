﻿using Newtonsoft.Json;
using PBP_Frontend.Enums;
using PBP_Frontend.Models;
using PBP_Frontend.Models.API;
using PBP_Frontend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WebAPIPBP.Controllers
{
    public class ValuesController : ApiController
    {
        private ListService listService = new ListService();
        private LocationService locationService = new LocationService();
        public List<string> errors = new List<string>();

        // GET api/values
        public HttpResponseMessage Get()
        {
            List list = listService.GetAvailableLists()?.FirstOrDefault();
            if (list == null)
            {
                var message = string.Format("A lista solicitada está vazia ou não existe.");
                HttpError erro = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NoContent, erro);
            }
            ListDTO lDTO = new ListDTO
            {
                ListId = list.ListId,
                Name = list.Name,
                Requester = list.Requester,
                ProductsList = list.ProductsList.Select(p => new ProductDTO {
                    ProductListId = p.ProductListId,
                    ProductId = p.ProductId,
                    Name = p.Product.Name,
                    ListId = p.ListId,
                    LocationId = p.Product.LocationId,
                    RequiredQuantity = p.RequiredQuantity
                }).ToList(),
                Locations = locationService.GetAll().Select(l => new LocationDTO
                {
                    LocationId = l.LocationId,
                    Building = l.Building,
                    Flat = l.Flat,
                    Street = l.Street,
                    Structure = l.Structure
                }).ToList()
            };
            try
            {
                var json = Json(list).ToString();
                return
                    new HttpResponseMessage()
                    {
                        Content = new StringContent(new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lDTO), Encoding.UTF8, "application/json")
                    };
            }
            catch (Exception e)
            {
                var message = string.Format("Erro ao converter lista.");
                HttpError erro = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]string value)
        {
            if (value == null || string.IsNullOrEmpty(value))
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum conteúdo encontrado."));
            ListDTO listDTO;
            try
            {
                listDTO = JsonConvert.DeserializeObject<ListDTO>(value);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao deserializar lista."));
            }
            if(listService.IsListDTOEmpty(listDTO))
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum conteúdo encontrado."));
            ChangeLog changeLog = new ChangeLog
            {
                ListId = listDTO.ListId,
                Date = DateTime.Now,
                ListStatusId = (int)ListStatusEnum.FINISHED
            };
            if (listService.SendListDb(listDTO, changeLog))
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, "Lista criada com sucesso."));
            else
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao criar lista."));
        }
    }
}
