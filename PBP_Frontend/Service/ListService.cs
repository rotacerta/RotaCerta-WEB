using PBP_Frontend.Enums;
using PBP_Frontend.Models;
using PBP_Frontend.Repository;
using PBP_Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PBP_Frontend.Service
{
    public class ListService
    {
        private ApplicationContext db;
        private readonly ListRepository listRepository;

        public ListService(ApplicationContext context)
        {
            db = context;
            listRepository = new ListRepository(db);
        }

        public List<string> PreInsertList(ListViewModel list)
        {
            using(DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                List<string> errors = new List<string>();
                try
                {
                    list.ListName = list?.ListName?.Trim();
                    if (list?.ListName?.Length > 0)
                    {
                        list.ListRequester = list?.ListRequester?.Trim();
                        if (list?.ListRequester?.Length > 0)
                        {
                            if (list?.ProductsChosen?.Where(pc => pc.RequiredQuantity <= 0)?.Count() == 0)
                            {
                                if (GetAvailableLists()?.Count == 0)
                                {
                                    if (InsertList(list).Count == 0)
                                    {
                                        db.SaveChanges();
                                        transaction.Commit();
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        errors.Add("Não foi possível criar a lista.");
                                    }
                                }
                                else
                                {
                                    errors.Add("Já existe uma lista aberta.");
                                }
                            }
                            else
                            {
                                errors.Add("Insira valores entre 0 e 300 no campo Quantidade.");
                            }
                        }
                        else
                        {
                            errors.Add("O campo Solicitante é obrigatório.");
                        }
                    }
                    else
                    {
                        errors.Add("O campo Nome é obrigatório.");
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    errors.Add("Não foi possível criar a lista.");
                }
                return errors;
            }
        }

        private List<string> InsertList(ListViewModel listVM)
        {
            List<string> errors = new List<string>();
            List list = new List { Name = listVM.ListName, Requester = listVM.ListRequester};
            db.Lists.Add(list);
            db.SaveChanges();
            ProductChosenService productChosenService = new ProductChosenService(db);
            errors.AddRange(productChosenService.InsertProductsChosen(list.ListId, listVM.ProductsChosen));
            if(errors.Count == 0)
            {
                ChangeLogService changeLogService = new ChangeLogService(db);
                errors.AddRange(changeLogService.InsertChangeLog(ListStatusEnum.AVAILABLE, list.ListId));
            }
            return errors;
        }

        public ListViewModel GetListForDetails(int listId)
        {
            ListViewModel listViewModel = new ListViewModel();
            return listViewModel;
        }

        public List<List> GetAvailableLists()
        {
            List<List> availablelists = listRepository.GetAvailableLists();
            foreach (List list in availablelists)
            {
                list.ChangeLogs = db.ChangeLogs.Where(cl => cl.ListId.Equals(list.ListId)).ToList();
                list.ProductsList = db.ProductLists.Where(pl => pl.ListId.Equals(list.ListId)).ToList();
            }
            return availablelists;
        }
    }
}