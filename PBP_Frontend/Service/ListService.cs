using PBP_Frontend.Enums;
using PBP_Frontend.Models;
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

        public ListService(ApplicationContext context)
        {
            db = context;
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
            //TODO: Criar um repositorio para criar uma query personalizada para trazer uma lista cujo ultimo changeLog seja AVALIABLE
            List list = new List { Name = listVM.ListName, Requester = listVM.ListRequester};
            db.Lists.Add(list);
            db.SaveChanges();
            ProductChosenService productChosenService = new ProductChosenService(db);
            errors.AddRange(productChosenService.InsertProductsChosen(list.ListId, listVM.ProductsChosen));
            if(errors.Count == 0)
            {
                ChangeLogService changeLogService = new ChangeLogService(db);
                errors.AddRange(changeLogService.InsertChangeLog(ListStatusEnum.AVALIABLE, list.ListId));
            }
            return errors;
        }

        public ListViewModel GetListForDetails(int listId)
        {
            ListViewModel listViewModel = new ListViewModel();
            return listViewModel;
        }
    }
}