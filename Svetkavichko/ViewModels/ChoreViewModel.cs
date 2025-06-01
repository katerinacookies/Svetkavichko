using Svetkavichko.Data;
using Svetkavichko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svetkavichko.ViewModels
{
    public class ChoreViewModel
    {
        private readonly SvetkavichkoDbContext _context;

        public ChoreViewModel(SvetkavichkoDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateAsync()
        {
            try
            {
                if (_context == null)
                {
                    return "";
                }
                List<Chore> choresFromDb = _context.Chores.ToList();
                int choreCount = choresFromDb.Count;

                Random rnd = new Random();
                int randomChoreId = rnd.Next(0, choreCount - 1);
                string rndChore = choresFromDb[randomChoreId].Name;
                return rndChore;

            }
            catch (Exception ex)
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Shell.Current.DisplayAlert("Грешка", ex.Message, "Добре");
                });
                return "";
            }
        }
    }
}
