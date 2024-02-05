namespace CoolStudent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var ctx = new CoolStudent.CoolContext();

            //var proffesors = new List<Proffesor>
            //{
            //    new Proffesor { Name = "Снейп", Age = 33 },
            //    new Proffesor { Name = "Думбльдор", Age = 77 }
            //};

            //ctx.Proffesors.AddRange(proffesors);
            //ctx.SaveChanges();

            //var fac1 = new Facultet { Name = "Слизерин", Proffesor = proffesors[0] };
            //ctx.Facultetes.Add(fac1);
            //ctx.SaveChanges();

            //ctx.Students.Add(new Student { Name = "Bob", Age = 20, Curse = 3, Facultet = fac1 });
            //ctx.Students.Add(new Student { Name = "Bill", Age = 21, Curse = 4, Facultet = fac1 });
            //ctx.SaveChanges();

            ctx.Students.ToArray();

            var fac1 = ctx.Facultetes.First();

            //fac1.Students
        }
    }
}
