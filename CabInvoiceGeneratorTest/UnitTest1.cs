using CabInvoiceGeneratorProblem;

namespace CabInvoiceGeneratorTest
{
    public class InvoiceTests
    {
        InvoiceGenerator invoiceGenerator = null;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        //TC1
        public void givenDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 8.0;
            int time = 12;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            System.Console.WriteLine("fare is : " + fare);
            Assert.AreEqual(92, fare, 0.0);
        }
        [Test]
        //TC 2
        public void GivenMultipleRide_ShouldReturn_InvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }
        [Test]
        //TC 3
        public void GivenMultipleRide_ShouldReturn_EnhancedInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.2, 2) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);
            Assert.AreEqual(expectedSummary, summary);
        }
        //[Test]
        ////TC 4
        //public void GivenUserId_UsingInvoiceSummary_ShouldReturnsInvoice()
        //{
        //    invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
        //    Ride[] rides = { new Ride(2, 10), new Ride(0.2, 2) };
        //    invoiceGenerator.AddRides("user1", rides);
        //    InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("user1");
        //    InvoiceSummary expectedSummary = new InvoiceSummary(2, 35, "user1");   //no of rides, total, userid
        //    Assert.AreEqual(expectedSummary, summary);
        //}
    }
}