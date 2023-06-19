using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _6_14MUIHomework.Data
{
    public class MaaserRepo
    {
        private readonly string _connectionString;

        public MaaserRepo(String connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddIncome (Income income)
        {
            using var context = new MaaserDb(_connectionString);
            context.Income.Add(income);
            context.SaveChanges();
        }

        public List<IncomeWithSource> GetIncomesWithSources()
        {
            using var context = new MaaserDb(_connectionString);
            var list = context.Income.Include(i => i.Source).ToList();
            var response = new List<IncomeWithSource>();

            foreach (var i in list)
            {
                response.Add(new IncomeWithSource
                {
                    Id = i.Id,
                    Amount = i.Amount,
                    SourceId = i.SourceId,
                    Date = i.Date,
                    SourceName = i.Source.SourceName
                });
            }
            return response;
        }

        public List<Source> GetGroupedIncomes()
        {
            using var context = new MaaserDb(_connectionString);
            return context.Sources.Include(s => s.Incomes).ToList();

        }

        public List<Source> GetSources()
        {
            using var context = new MaaserDb(_connectionString);
            return context.Sources.Distinct().ToList();
        }

        public void AddMaaser(Maaser maaser)
        {
            using var context = new MaaserDb(_connectionString);
            context.Maaser.Add(maaser);
            context.SaveChanges();
        }

        public List<Maaser> GetMaaser()
        {
            using var context = new MaaserDb(_connectionString);
            return context.Maaser.ToList();
        }

        public void DeleteSource(Source source)
        {
            using var context = new MaaserDb(_connectionString);
            context.Database.ExecuteSqlInterpolated($"DELETE FROM Sources WHERE id = {source.Id}");
        }

        public Source GetSourceForString(string source)
        {
            using var context = new MaaserDb(_connectionString);
            return context.Sources.FirstOrDefault(s => s.SourceName == source);
        }

        public void AddSource(Source source)
        {
            using var context = new MaaserDb(_connectionString);
            context.Sources.Add(source);
            context.SaveChanges();
        }

        public void EditSource(Source source)
        {
            using var context = new MaaserDb(_connectionString);
            context.Sources.Update(source);
            context.SaveChanges();
        }

        public decimal GetTotalIncome()
        {
            using var context = new MaaserDb(_connectionString);
            return context.Income.Sum(i => i.Amount);
        }

        public decimal GetTotalMaaser()
        {
            using var context = new MaaserDb(_connectionString);
            return context.Maaser.Sum(m => m.Amount);
        }


    }
}
