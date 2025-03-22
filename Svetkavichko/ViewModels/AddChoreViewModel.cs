using Svetkavichko.Data;
using Svetkavichko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svetkavichko.ViewModels
{
    public class AddChoreViewModel
    {
        private readonly SvetkavichkoDbContext _context;

        public AddChoreViewModel(SvetkavichkoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddChoreAsync(string? choreText)
        {
            try
            {
                if (_context == null)
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(choreText))
                {
                    await MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        Shell.Current.DisplayAlert("Грешка", "Попълнете всички полета!", "Добре");
                    });
                    return false;
                }
                var choreFromDb = await Task.Run(async () =>
                    _context.Chores.FirstOrDefault(c => c.Name == choreText));

                if (choreFromDb != null)
                {
                    await MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        Shell.Current.DisplayAlert("Упси", "Тази задачка вече съществува!", "Добре");
                    });
                }

                var newChore = new Chore
                {
                    Name = choreText,
                    IsDoneToday = false,
                    DateDone = DateTime.Today
                };

                await _context.Chores.AddAsync(newChore);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Shell.Current.DisplayAlert("Грешка", ex.Message, "Добре");
                });
                return false;
            }
        }
    }
}
