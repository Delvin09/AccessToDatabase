using Microsoft.EntityFrameworkCore;

namespace AccessToDatabase_Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var ctx = new TestContext();

            var entity = ctx.Addresses
                .Include(a => a.Company)
                    .ThenInclude(c => c.Addresses)
                .Include(a => a.Company)
                    .ThenInclude(c => c.Users)
                .FirstOrDefault(a => a.Id == 7);

            foreach (var a in ctx.Addresses)
                Console.WriteLine(a);
        }
    }
}
