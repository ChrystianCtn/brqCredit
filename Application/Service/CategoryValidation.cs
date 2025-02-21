using brqCredit.Application.Class;
using brqCredit.Application.Interface;
using Microsoft.Extensions.Configuration;

namespace brqCredit.Application.Service
{
    public class CategoryValidation
    {
        private readonly List<Category> _categories;

        public CategoryValidation(IConfiguration config)
        {
            _categories = new List<Category>()
            {
                new ExpiredCategory(int.Parse(config["maxExpiredDays"]?.ToString())),
                new MediumRiskCategory(),
                new HighRiskCategory(),
            };
        }

        public string ValidateCategory(ITrade trade, DateTime referenceDate)
        {
            foreach (var category in _categories)
            {
                var validationResult = category.SelectCategory(trade, referenceDate);
                if (!string.IsNullOrEmpty(validationResult)) 
                    return validationResult;
            }
            return "NORISK";
        }
    }
}
