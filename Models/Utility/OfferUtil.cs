
namespace Models
{
    public static class OfferUtil
    {
        public static Offer GetOffer()
        {
            Offer offers = new Offer()
            {
                ID = 1,
                OfferInPercentage = 10
            };
            return offers;
        }
    }
}
