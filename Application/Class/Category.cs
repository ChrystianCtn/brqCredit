using brqCredit.Application.Interface;

namespace brqCredit.Application.Class
{
    public abstract class Category
    {
        public abstract string? SelectCategory(ITrade trade, DateTime referenceDate);
    }
    
    public class ExpiredCategory : Category
    {
        private readonly int _maxExpiredDays;

        public ExpiredCategory(int maxExpiredDays)
        {
            _maxExpiredDays = maxExpiredDays;
        }
        public override string? SelectCategory(ITrade trade, DateTime referenceDate)
        {
            if ((referenceDate - trade.NextPaymentDate).Days > _maxExpiredDays)
                return "EXPIRED";
            return null;
        }
    }

    public class MediumRiskCategory : Category
    {
        public override string? SelectCategory(ITrade trade, DateTime referenceDate)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "Public")
                return "MEDIUMRISK";
            return null;
        }
    }

    public class HighRiskCategory : Category
    {
        public override string? SelectCategory(ITrade trade, DateTime referenceDate)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "Private")
                return "HIGHRISK";
            return null;
        }
    }
}
