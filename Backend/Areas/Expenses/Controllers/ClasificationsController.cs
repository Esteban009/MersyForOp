﻿namespace Backend.Areas.Expenses.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.TRK;
    using CommonTasksLib.Data;
    using Backend.Controllers;

    public class ClasificationsController : PsBaseController
    { 
        #region TransactionController

        public async Task<ActionResult> CreateTransactionM(int id)
        {

            var userId = await GetAuthorId();
            if (id == 1 || id == 3)
            {
                ViewBag.AccountId = new SelectList(_db.Accounts.Where(p => p.Wallet.AuthorId == userId && p.AccountType.OriginId == 1), "AccountId", "Description");
                ViewBag.OriginId = id == 1 ? new SelectList(_db.Origins, "OriginId", "Simbol", 1) : new SelectList(_db.Origins, "OriginId", "Simbol", 2);
                ViewBag.Indicator = 1;
            }
            else
            {
                ViewBag.AccountId = new SelectList(_db.Accounts.Where(p => p.Wallet.AuthorId == userId && p.AccountType.OriginId == 2), "AccountId", "Description");
                ViewBag.OriginId = id == 2 ? new SelectList(_db.Origins, "OriginId", "Simbol", 1) : new SelectList(_db.Origins, "OriginId", "Simbol", 2);
                // ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Simbol",2);
                ViewBag.Indicator = 2;
            }
            ViewBag.AccountId2 = new SelectList(_db.Accounts.Where(p => p.Wallet.AuthorId == userId), "AccountId", "Description");

            ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description");
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name");

            var view = new Operation { StatusId = 1, Date = DateTime.Now, Recurrent = true };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTransactionM(Operation transaction)
        {
            if (!ModelState.IsValid)
            {
                var userId = await GetAuthorId();
                //  ViewBag.AccountId = new SelectList(_db.Accounts.Where(p => p.Wallet.UserId == userId && p.OriginId == transaction.OriginId), "AccountId", "Description", transaction.TagId);
                ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Simbol", transaction.TagId);

                ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description", transaction.TagId);
                ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name", transaction.PeriodicityId);
                return View(transaction);
            }

            //Transaction.PreviousAmount = Transaction.Amount;

            _db.Operations.Add(transaction);

            var label = await _db.Accounts.FindAsync(transaction.AccountId);
            var tag = await _db.Tags.FindAsync(transaction.TagId);

            if (label == null)
            {
                return View("Error");
            }

            if (tag == null)
            {
                return View("Error");
            }

            if (transaction.OriginId == 1)
            {
                if (transaction.Account.AccountType.OriginId == 1)
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount += transaction.Amount;
                    tag.Amount += transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount += transaction.Amount;
                }
                else
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount -= transaction.Amount;
                    tag.Amount -= transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount -= transaction.Amount;
                }

            }
            else
            {
                //label.PreviousAmount = label.Amount;
                //label.Amount -= Transaction.Amount;
                //tag.Amount -= Transaction.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //label.Wallet.Amount -= Transaction.Amount;

                //label.Amount2 += Transaction.Amount;
                //tag.Amount2 += Transaction.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //label.Wallet.Amount2 += Transaction.Amount;

                if (transaction.Account.AccountType.OriginId == 1)
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount -= transaction.Amount;
                    tag.Amount -= transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount -= transaction.Amount;
                }
                else
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount += transaction.Amount;
                    tag.Amount += transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount += transaction.Amount;
                }
            }
            transaction.PeriodicityId = 1;

            _db.Entry(label).State = EntityState.Modified;
            _db.Entry(tag).State = EntityState.Modified;
           // await _db.SaveChangesAsync();
            //  var tag2 = await _db.Tags.FindAsync(transaction.TagId);

            if (transaction.Recurrent) //TODO: hacer el proceso de repeticion
            {
          //  var   _db2 = new DataContext();
        var label2 = await _db.Accounts.FindAsync(transaction.AccountId2);

                var transaction2 = new Operation
                {
                    AccountId = Convert.ToInt32(transaction.AccountId2),
                    Date = transaction.Date,
                    OriginId = transaction.OriginId,
                    AccountId2 = transaction.AccountId,
                    TagId = transaction.TagId,
                    Amount = transaction.Amount,
                    Recurrent = transaction.Recurrent,
                    PeriodicityId = transaction.PeriodicityId,
                    Observations = transaction.Observations,
                    StatusId = transaction.StatusId
                };


                if (label2 == null)
                {
                    return View("Error");
                }
                
                if (transaction.OriginId == 1)
                {
                    if (transaction.Account.AccountType.OriginId == 1)
                    {
                        label2.Amount -= transaction2.Amount;
                        //  tag2.Amount -= transaction.Amount;
                        label2.Wallet.Amount -= transaction2.Amount;
                    }
                    else
                    {
                        label2.Amount -= transaction2.Amount;
                        //  tag2.Amount -= transaction.Amount;
                        label2.Wallet.Amount -= transaction2.Amount;
                    }

                }
                else
                {

                    if (transaction.Account.AccountType.OriginId == 1)
                    {
                        //label.PreviousAmount = label.Amount;
                        label2.Amount += transaction2.Amount;
                        //   tag2.Amount -= transaction.Amount;
                        //label.Clasification.PreviousAmount = label.Clasification.Amount;
                        label2.Wallet.Amount += transaction2.Amount;
                    }
                    else
                    {
                        //label.PreviousAmount = label.Amount;
                        label2.Amount -= transaction2.Amount;
                        //   tag2.Amount += transaction.Amount;
                        //label.Clasification.PreviousAmount = label.Clasification.Amount;
                        label2.Wallet.Amount -= transaction2.Amount;
                    }
                }
                
               // transaction2.AccountId = Convert.ToInt32(transaction2.AccountId2);
                //transaction2.AccountId2 = null;
                _db.Operations.Add(transaction2);
                _db.Entry(label2).State = EntityState.Modified;
              //  transaction2.PeriodicityId = 1;

              
               // _db.Entry(tag).State = EntityState.Modified;
            
            }
            //else
            //{

            //}
               await _db.SaveChangesAsync();

            return RedirectToAction("Resume");
        }

        public async Task<ActionResult> DetailsTransaction(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var transaction = await _db.Operations.FirstOrDefaultAsync(p => p.OperationId == id);

            if (transaction == null)
            {
                return View("Error");
            }
            var userId = await GetAuthorId();
            // ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Description", Transaction.OriginId);
            ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Simbol", transaction.OriginId);
            ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description", transaction.TagId);
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name", transaction.PeriodicityId);

            return View(transaction);
        }

        public async Task<ActionResult> CreateTransaction(int id)
        {

            var userId = await GetAuthorId();
            if (id == 1 || id == 3)
            {
                ViewBag.AccountId = new SelectList(_db.Accounts.Where(p => p.Wallet.AuthorId == userId && p.AccountType.OriginId == 1), "AccountId", "Description");
                ViewBag.OriginId = id == 1 ? new SelectList(_db.Origins, "OriginId", "Simbol", 1) : new SelectList(_db.Origins, "OriginId", "Simbol", 2);
            }
            else
            {
                ViewBag.AccountId = new SelectList(_db.Accounts.Where(p => p.Wallet.AuthorId == userId && p.AccountType.OriginId == 2), "AccountId", "Description");
                ViewBag.OriginId = id == 2 ? new SelectList(_db.Origins, "OriginId", "Simbol", 1) : new SelectList(_db.Origins, "OriginId", "Simbol", 2);
                // ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Simbol",2);
            }
            ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description");
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name");

            var view = new Operation { StatusId = 1, Date = DateTime.Now };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTransaction(Operation transaction)
        {
            if (!ModelState.IsValid)
            {
                var userId = await GetAuthorId();
                //  ViewBag.AccountId = new SelectList(_db.Accounts.Where(p => p.Wallet.UserId == userId && p.OriginId == transaction.OriginId), "AccountId", "Description", transaction.TagId);
                ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Simbol", transaction.TagId);

                ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description", transaction.TagId);
                ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name", transaction.PeriodicityId);
                return View(transaction);
            }

            if (transaction.Recurrent) //TODO: hacer el proceso de repeticion
            {

            }
            else
            {
                transaction.PeriodicityId = 1;
            }

            //Transaction.PreviousAmount = Transaction.Amount;

            _db.Operations.Add(transaction);

            var label = await _db.Accounts.FindAsync(transaction.AccountId);
            var tag = await _db.Tags.FindAsync(transaction.TagId);

            if (label == null)
            {
                return View("Error");
            }

            if (tag == null)
            {
                return View("Error");
            }

            if (transaction.OriginId == 1)
            {
                if (transaction.Account.AccountType.OriginId == 1)
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount += transaction.Amount;
                    tag.Amount += transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount += transaction.Amount;
                }
                else
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount -= transaction.Amount;
                    tag.Amount -= transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount -= transaction.Amount;
                }

            }
            else
            {
                //label.PreviousAmount = label.Amount;
                //label.Amount -= Transaction.Amount;
                //tag.Amount -= Transaction.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //label.Wallet.Amount -= Transaction.Amount;

                //label.Amount2 += Transaction.Amount;
                //tag.Amount2 += Transaction.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //label.Wallet.Amount2 += Transaction.Amount;

                if (transaction.Account.AccountType.OriginId == 1)
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount -= transaction.Amount;
                    tag.Amount -= transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount -= transaction.Amount;
                }
                else
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount += transaction.Amount;
                    tag.Amount += transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount += transaction.Amount;
                }
            }

            _db.Entry(label).State = EntityState.Modified;
            _db.Entry(tag).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return RedirectToAction("Resume");
        }

        public async Task<ActionResult> DeleteTransaction(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var transaction = await _db.Operations.FindAsync(id);

            if (transaction == null)
            {
                return View("Error");
            }

            var label = await _db.Accounts.FindAsync(transaction.AccountId);
            var tag = await _db.Tags.FindAsync(transaction.TagId);

            if (label == null)
            {
                return View("Error");
            }
            if (tag == null)
            {
                return View("Error");
            }
            if (transaction.OriginId == 1)
            {
                if (transaction.Account.AccountType.OriginId == 1)
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount -= transaction.Amount;
                    tag.Amount -= transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount -= transaction.Amount;
                }
                else
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount += transaction.Amount;
                    tag.Amount += transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount += transaction.Amount;
                }

            }
            else
            {
                //label.PreviousAmount = label.Amount;
                //label.Amount -= Transaction.Amount;
                //tag.Amount -= Transaction.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //label.Wallet.Amount -= Transaction.Amount;

                //label.Amount2 -= Transaction.Amount;
                //tag.Amount2 -= Transaction.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //label.Wallet.Amount2 -= Transaction.Amount;

                if (transaction.Account.AccountType.OriginId == 1)
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount += transaction.Amount;
                    tag.Amount += transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount += transaction.Amount;
                }
                else
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount -= transaction.Amount;
                    tag.Amount -= transaction.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount -= transaction.Amount;
                }
            }
            //if (Transaction.OriginId == 2)
            //{
            //    //label.PreviousAmount = label.Amount;
            //    label.Amount += Transaction.Amount;
            //    tag.Amount += Transaction.Amount;
            //    //label.Clasification.PreviousAmount = label.Clasification.Amount;
            //    label.Wallet.Amount += Transaction.Amount;
            //}
            //else
            //{
            //    //label.PreviousAmount = label.Amount;
            //    //label.Amount -= Transaction.Amount;
            //    //tag.Amount -= Transaction.Amount;
            //    ////label.Clasification.PreviousAmount = label.Clasification.Amount;
            //    //label.Wallet.Amount -= Transaction.Amount;
            //    label.Amount2 += Transaction.Amount;
            //    tag.Amount2 += Transaction.Amount;
            //    //label.Clasification.PreviousAmount = label.Clasification.Amount;
            //    label.Wallet.Amount2 += Transaction.Amount;
            //}

            _db.Operations.Remove(transaction);
            _db.Entry(label).State = EntityState.Modified;
            _db.Entry(tag).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return RedirectToAction($"DetailsLabel/{transaction.AccountId}");

        }

        #endregion

        #region BudgetDetailController

        public async Task<ActionResult> DetailsBudgetDetail(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var budgetDetail = await _db.BudgetDetails.FirstOrDefaultAsync(p => p.BudgetDetailId == id);

            if (budgetDetail == null)
            {
                return View("Error");
            }
            var userId = await GetAuthorId();
            // ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Description", BudgetDetail.OriginId);
            ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Simbol", budgetDetail.OriginId);
            ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description", budgetDetail.TagId);
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name", budgetDetail.PeriodicityId);

            return View(budgetDetail);
        }

        public async Task<ActionResult> CreateBudgetDetail(int id)
        {
            var label = await _db.Budgets.FindAsync(id);

            if (label == null)
            {
                return View("Error");
            }
            var userId = await GetAuthorId();
            ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Simbol");
            ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description");
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name");

            var view = new BudgetDetail { BudgetId = id, StatusId = 1, Date = DateTime.Now };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateBudgetDetail(BudgetDetail budgetDetail)
        {
            if (!ModelState.IsValid)
            {
                var userId = await GetAuthorId();
                ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description", budgetDetail.TagId);
                ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name", budgetDetail.PeriodicityId);
                return View(budgetDetail);
            }

            if (budgetDetail.Recurrent) //TODO: hacer el proceso de repeticion
            {

            }
            else
            {
                budgetDetail.PeriodicityId = 1;
            }

            //BudgetDetail.PreviousAmount = BudgetDetail.Amount;

            _db.BudgetDetails.Add(budgetDetail);

            var label = await _db.Budgets.FindAsync(budgetDetail.BudgetId);

            if (label == null)
            {
                return View("Error");
            }

            if (budgetDetail.OriginId == 1)
            {
                //label.PreviousAmount = label.Amount;
                label.Amount += budgetDetail.Amount;
                //label.Clasification.PreviousAmount = label.Clasification.Amount;
                // label.Budget.Amount += budgetDetail.Amount;
            }
            else
            {
                //label.PreviousAmount = label.Amount;
                label.Amount -= budgetDetail.Amount;
                //label.Clasification.PreviousAmount = label.Clasification.Amount;
                // label.Budget.Amount -= budgetDetail.Amount;
                // label.Amount2 += budgetDetail.Amount;
            }

            _db.Entry(label).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return RedirectToAction($"DetailsBudget/{budgetDetail.BudgetId}");
        }

        public async Task<ActionResult> DeleteBudgetDetail(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var budgetDetail = await _db.BudgetDetails.FindAsync(id);

            if (budgetDetail == null)
            {
                return View("Error");
            }

            var label = await _db.Budgets.FindAsync(budgetDetail.BudgetId);

            if (label == null)
            {
                return View("Error");
            }
            if (budgetDetail.OriginId == 2)
            {
                //label.PreviousAmount = label.Amount;
                label.Amount += budgetDetail.Amount;
                //label.Clasification.PreviousAmount = label.Clasification.Amount;
                //  label.Budget.Amount += budgetDetail.Amount;
            }
            else
            {
                //label.PreviousAmount = label.Amount;
                label.Amount -= budgetDetail.Amount;
                //label.Clasification.PreviousAmount = label.Clasification.Amount;
                //  label.Budget.Amount -= budgetDetail.Amount;
            }

            _db.BudgetDetails.Remove(budgetDetail);
            _db.Entry(label).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return RedirectToAction($"DetailsBudget/{budgetDetail.BudgetId}");

        }

        #endregion

        #region Budgets

        public async Task<ActionResult> IndexBudget()
        {
            try
            {
                var budgets = _db.Budgets.Include(c => c.Status).Include(c => c.User);
                return View(await budgets.ToListAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public async Task<ActionResult> DetailsBudget(int? id)
        {
            if (id == null)
            {
                 return View("Error");
            }
            var budget = await _db.Budgets.FindAsync(id);
            if (budget == null)
            {
                return View("Error");
            }
            return View(budget);
        }
        
        public async Task<ActionResult> CreateBudget()
        {
            int userid = await GetAuthorId();
            var budget = new Budget()
            {
                UserId = userid,
                StatusId = 1
            };
            return View(budget);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateBudget(Budget budget)
        {

            if (ModelState.IsValid)
            {
                _db.Budgets.Add(budget);
                await _db.SaveChangesAsync();
                return RedirectToAction("IndexBudget");
            }

            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", budget.StatusId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", budget.UserId);
            return View(budget);
        }

        public async Task<ActionResult> EditBudget(int? id)
        {
            if (id == null)
            {
                 return View("Error");
            }
            var budget = await _db.Budgets.FindAsync(id);
            if (budget == null)
            {
                return View("Error");
            }
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", budget.StatusId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", budget.UserId);
            return View(budget);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditBudget(Budget budget)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(budget).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("IndexBudget");
            }
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", budget.StatusId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", budget.UserId);
            return View(budget);
        }

        public async Task<ActionResult> DeleteBudget(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var budget = await _db.Budgets.FindAsync(id);

            if (budget == null)
            {
                return View("Error");
            }

            _db.Budgets.Remove(budget);
            await _db.SaveChangesAsync();
            return RedirectToAction("IndexBudget");

        }

        #endregion

        #region OperationController

        public async Task<ActionResult> DetailsOperation(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var operation = await _db.Operations.FirstOrDefaultAsync(p => p.OperationId == id);

            if (operation == null)
            {
                return View("Error");
            }
            var userId = await GetAuthorId();
            // ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Description", operation.OriginId);
            ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Simbol", operation.OriginId);
            ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description", operation.TagId);
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name", operation.PeriodicityId);

            return View(operation);
        }

        public async Task<ActionResult> CreateOperation(int id)
        {
            var label = await _db.Accounts.FindAsync(id);

            if (label == null)
            {
                return View("Error");
            }
            var userId = await GetAuthorId();
            ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Simbol", label.AccountType.OriginId);
            ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description");
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name");

            var view = new Operation { AccountId = id, StatusId = 1, Date = DateTime.Now };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOperation(Operation operation)
        {
            if (!ModelState.IsValid)
            {
                var userId = await GetAuthorId();
                ViewBag.TagId = new SelectList(_db.Tags.Where(p => p.UserId == userId), "TagId", "Description", operation.TagId);
                ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name", operation.PeriodicityId);
                return View(operation);
            }

            if (operation.Recurrent) //TODO: hacer el proceso de repeticion
            {

            }
            else
            {
                operation.PeriodicityId = 1;
            }

            //operation.PreviousAmount = operation.Amount;

            _db.Operations.Add(operation);

            var label = await _db.Accounts.FindAsync(operation.AccountId);
            var tag = await _db.Tags.FindAsync(operation.TagId);

            if (label == null)
            {
                return View("Error");
            }

            if (tag == null)
            {
                return View("Error");
            }

            if (operation.OriginId == 1)
            {
                if (operation.Account.AccountType.OriginId == 1)
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount += operation.Amount;
                    tag.Amount += operation.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount += operation.Amount;
                }
                else
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount -= operation.Amount;
                    tag.Amount -= operation.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount -= operation.Amount;
                }

            }
            else
            {
                //label.PreviousAmount = label.Amount;
                //label.Amount -= operation.Amount;
                //tag.Amount -= operation.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //label.Wallet.Amount -= operation.Amount;

                //label.Amount2 += operation.Amount;
                //tag.Amount2 += operation.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //label.Wallet.Amount2 += operation.Amount;

                if (operation.Account.AccountType.OriginId == 1)
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount -= operation.Amount;
                    tag.Amount -= operation.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount -= operation.Amount;
                }
                else
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount += operation.Amount;
                    tag.Amount += operation.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount += operation.Amount;
                }
            }

            _db.Entry(label).State = EntityState.Modified;
            _db.Entry(tag).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return RedirectToAction($"DetailsLabel/{operation.AccountId}");
        }

        public async Task<ActionResult> DeleteOperation(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var operation = await _db.Operations.FindAsync(id);

            if (operation == null)
            {
                return View("Error");
            }

            var label = await _db.Accounts.FindAsync(operation.AccountId);
            var tag = await _db.Tags.FindAsync(operation.TagId);

            if (label == null)
            {
                return View("Error");
            }
            if (tag == null)
            {
                return View("Error");
            }
            if (operation.OriginId == 1)
            {
                if (operation.Account.AccountType.OriginId == 1)
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount -= operation.Amount;
                    tag.Amount -= operation.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount -= operation.Amount;
                }
                else
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount += operation.Amount;
                    tag.Amount += operation.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount += operation.Amount;
                }

            }
            else
            {
                //label.PreviousAmount = label.Amount;
                //label.Amount -= operation.Amount;
                //tag.Amount -= operation.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //label.Wallet.Amount -= operation.Amount;

                //label.Amount2 -= operation.Amount;
                //tag.Amount2 -= operation.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //label.Wallet.Amount2 -= operation.Amount;

                if (operation.Account.AccountType.OriginId == 1)
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount += operation.Amount;
                    tag.Amount += operation.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount += operation.Amount;
                }
                else
                {
                    //label.PreviousAmount = label.Amount;
                    label.Amount -= operation.Amount;
                    tag.Amount -= operation.Amount;
                    //label.Clasification.PreviousAmount = label.Clasification.Amount;
                    label.Wallet.Amount -= operation.Amount;
                }
            }
            //if (operation.OriginId == 2)
            //{
            //    //label.PreviousAmount = label.Amount;
            //    label.Amount += operation.Amount;
            //    tag.Amount += operation.Amount;
            //    //label.Clasification.PreviousAmount = label.Clasification.Amount;
            //    label.Wallet.Amount += operation.Amount;
            //}
            //else
            //{
            //    //label.PreviousAmount = label.Amount;
            //    //label.Amount -= operation.Amount;
            //    //tag.Amount -= operation.Amount;
            //    ////label.Clasification.PreviousAmount = label.Clasification.Amount;
            //    //label.Wallet.Amount -= operation.Amount;
            //    label.Amount2 += operation.Amount;
            //    tag.Amount2 += operation.Amount;
            //    //label.Clasification.PreviousAmount = label.Clasification.Amount;
            //    label.Wallet.Amount2 += operation.Amount;
            //}

            _db.Operations.Remove(operation);
            _db.Entry(label).State = EntityState.Modified;
            _db.Entry(tag).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return RedirectToAction($"DetailsLabel/{operation.AccountId}");

        }

        #endregion

        #region Account

        public async Task<ActionResult> DetailsLabel(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var label = await _db.Accounts.FirstOrDefaultAsync(p => p.AccountId == id);

            if (label == null)
            {
                return View("Error");
            }

            ViewBag.AccountTypeId = _db.AccountTypes.ToSelectListItems(p => p.Name, p => p.AccountTypeId.ToString(), l => l.AccountTypeId == label.AccountTypeId); //el primer corresponde al textfield y lue
            ViewBag.CurrencyId = _db.Currencies.ToSelectListItems(p => p.Code, p => p.CurrencyId.ToString(), l => l.CurrencyId == label.CurrencyId);  
            
            // ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Description", label.AccountType.OriginId);
           

            return View(label);
        }

        public async Task<ActionResult> CreateLabel(int id)
        {
            var clasification = await _db.Wallets.FindAsync(id);

            if (clasification == null)
            {
                return View("Error");
            }

            ViewBag.AccountTypeId = _db.AccountTypes.ToSelectListItems(p => p.Name, p => p.AccountTypeId.ToString()); //el primer corresponde al textfield y lue
               ViewBag.CurrencyId = _db.Currencies.ToSelectListItems(p => p.Code, p => p.CurrencyId.ToString());
            
            var view = new Account { WalletId = id, StatusId = 1 };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateLabel(Account label)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AccountTypeId = _db.AccountTypes.ToSelectListItems(p => p.Name, p => p.AccountTypeId.ToString(), l => l.AccountTypeId == label.AccountTypeId); //el primer corresponde al textfield y lue
                // ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Description", label.AccountType.OriginId);
                ViewBag.CurrencyId = _db.Currencies.ToSelectListItems(p => p.Code, p => p.CurrencyId.ToString(), l => l.CurrencyId == label.CurrencyId);

                return View(label);
            }

            _db.Accounts.Add(label);

            var clasification = await _db.Wallets.FindAsync(label.WalletId);

            if (clasification == null)
            {
                return View("Error");
            }
            //Cuando queremos cargar una referencia a una tabla en caso de que este no la cargue
            _db.Entry(label).Reference(p => p.AccountType).Load();

            if (label.AccountType.OriginId == 1)
            {
                //label.PreviousAmount = label.Amount;
                clasification.Amount += label.Amount;
                //label.Clasification.PreviousAmount = label.Clasification.Amount;
                clasification.Amount += label.Amount;
            }
            else
            {
                //label.PreviousAmount = label.Amount;
                //clasification.Amount -= label.Amount;
                ////label.Clasification.PreviousAmount = label.Clasification.Amount;
                //clasification.Amount -= label.Amount;

                clasification.Amount -= label.Amount;
                //label.Clasification.PreviousAmount = label.Clasification.Amount;
                //clasification.Amount2 += label.Amount;

            }

            _db.Entry(clasification).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return RedirectToAction($"DetailsLabel/{label.AccountId}");
        }

        public async Task<ActionResult> EditLabel(int id)
        {

            var label = await _db.Accounts.FirstOrDefaultAsync(p => p.AccountId == id);

            if (label == null)
            {
                return View("Error");
            }
            ViewBag.AccountTypeId = _db.AccountTypes.ToSelectListItems(p=>p.Name, p=>p.AccountTypeId.ToString() , l => l.AccountTypeId== label.AccountTypeId); //el primer corresponde al textfield y lue                                                                                                                                                //, "AccountTypeId", "Name", label.AccountTypeId);
            // ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Description", label.AccountType.OriginId);
            ViewBag.CurrencyId = _db.Currencies.ToSelectListItems(p => p.Code, p => p.CurrencyId.ToString(), l => l.CurrencyId == label.CurrencyId);

            return View(label);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditLabel(Account label)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AccountTypeId = _db.AccountTypes.ToSelectListItems(p => p.Name, p => p.AccountTypeId.ToString(), l => l.AccountTypeId == label.AccountTypeId); //el primer corresponde al textfield y lue
                //  ViewBag.OriginId = new SelectList(_db.Origins, "OriginId", "Description", label.AccountType.OriginId);
                ViewBag.CurrencyId = _db.Currencies.ToSelectListItems(p => p.Code, p => p.CurrencyId.ToString(), l => l.CurrencyId == label.CurrencyId);

                return View(label);

            }
            _db.Entry(label).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return RedirectToAction($"DetailsLabel/{label.AccountId}");
        }

        public async Task<ActionResult> DeleteLabel(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var label = await _db.Accounts.FindAsync(id);

            if (label == null)
            {
                return View("Error");
            }

            _db.Accounts.Remove(label);

            await _db.SaveChangesAsync();
            return RedirectToAction($"Details/{label.WalletId}");

        }

        #endregion

        #region Tags

        public async Task<ActionResult> IndexTag()
        {
            try
            {
                int userid = await GetAuthorId();
                var tags = _db.Tags.Where( p=>p.User.AuthorId==userid).Include(c => c.Status).Include(c => c.User);
                return View(await tags.ToListAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public async Task<ActionResult> DetailsTag(int? id)
        {
            if (id == null)
            {
                 return View("Error");
            }
            var tag = await _db.Tags.FindAsync(id);
            if (tag == null)
            {
                return View("Error");
            }
            return View(tag);
        }

        public async Task<ActionResult> CreateTag()
        {
            int userid = await GetAuthorId();
            var tag = new Tag()
            {
                UserId = userid,
                StatusId = 1
            };
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTag(Tag tag)
        {

            if (ModelState.IsValid)
            {
                _db.Tags.Add(tag);
                await _db.SaveChangesAsync();
                return RedirectToAction("IndexTag");
            }

            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", tag.StatusId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", tag.UserId);
            return View(tag);
        }

        public async Task<ActionResult> EditTag(int? id)
        {
            if (id == null)
            {
                 return View("Error");
            }
            var tag = await _db.Tags.FindAsync(id);
            if (tag == null)
            {
                return View("Error");
            }
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", tag.StatusId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", tag.UserId);
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTag(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(tag).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("IndexTag");
            }
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", tag.StatusId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", tag.UserId);
            return View(tag);
        }

        public async Task<ActionResult> DeleteTag(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var tag = await _db.Tags.FindAsync(id);

            if (tag == null)
            {
                return View("Error");
            }

            _db.Tags.Remove(tag);
            await _db.SaveChangesAsync();
            return RedirectToAction("IndexTag");

        }

        #endregion

        #region Wallet
        //public async Task<int> GetAuthorId()
        //{
        //     if (Session["AuthorId"] != null && Convert.ToInt32(Session["AuthorId"])!=0 ) return Convert.ToInt32(Session["AuthorId"]);
        //    var manager =
        //        new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //    var currentUser = manager.FindById(User.Identity.GetUserId());
        //    Session["AuthorId"] = await UsersHelper.GetAuthorId(currentUser.Email);
        //    return Convert.ToInt32(Session["AuthorId"]);
        //}
        public async Task<ActionResult> Resume()
        {
            try
            {
                int userid = await GetAuthorId();
                //  var clasifications = _db.Wallets.Include(c => c.Status).Include(c => c.Author).Where(p => p.AuthorId == userid);
                // return View(await clasifications.ToListAsync());
                var author = await _db.Authors.FindAsync(userid);
                if (author == null)
                {
                    return View("Error");
                }
                return View(author);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public async Task<ActionResult> Index()
        {
            try
            {
                int userid = await GetAuthorId();
                var clasifications = _db.Wallets.Include(c => c.Status).Include(c => c.Accounts).Where(p => p.AuthorId == userid);
                return View(await clasifications.ToListAsync());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                 return View("Error");
            }
            var clasification = await _db.Wallets.FindAsync(id);
            if (clasification == null)
            {
                return View("Error");
            }
            return View(clasification);
        }

        public async Task<ActionResult> Create()
        {
            int userid = await GetAuthorId();
            var clasification = new Wallet()
            {
                AuthorId = userid,
                StatusId = 1
            };
            return View(clasification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Wallet clasification)
        {

            if (ModelState.IsValid)
            {
                _db.Wallets.Add(clasification);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", clasification.StatusId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", clasification.AuthorId);
            return View(clasification);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                 return View("Error");
            }
            var clasification = await _db.Wallets.FindAsync(id);
            if (clasification == null)
            {
                return View("Error");
            }
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", clasification.StatusId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", clasification.AuthorId);
            return View(clasification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Wallet clasification)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(clasification).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", clasification.StatusId);
            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", clasification.AuthorId);
            return View(clasification);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var clasification = await _db.Wallets.FindAsync(id);

            if (clasification == null)
            {
                return View("Error");
            }

            _db.Wallets.Remove(clasification);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        #endregion               

    }
}
