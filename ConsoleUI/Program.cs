using Entities.Concrete;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Linq;
using Entities.Concrete.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            

            ColorManager colorManager = new ColorManager(new EFColorDal());
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            CarManager carManager = new CarManager(new EFCarDal());
            CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            UserManager userManager = new UserManager(new EFUserDal());

            //Test(colorManager, brandManager, carManager);
            //CarDtoTest(brandManager, colorManager, carManager);
            var result = userManager.Delete(new User{Id = 1});
           Console.WriteLine(result.Message);

        }

        private static void CarDtoTest(BrandManager brandManager, ColorManager colorManager, CarManager carManager)
        {
            Car car = new Car
            {
                Id = 0,
                BrandId = brandManager.Get(b => b.BrandName == "Marka1").Data.Id,
                ColorId = colorManager.Get(c => c.ColorName == "Siyah").Data.Id,
                ModelYear = Convert.ToDateTime("03.02.1999"),
                DailyPrice = 3700,
                Description = "Araç birin açıklaması"
            };
            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka2").Data.Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Kirmizi").Data.Id;
            car.ModelYear = Convert.ToDateTime("03.02.2000");
            car.DailyPrice = 4900;
            car.Description = "Araç ikinin açıklaması";

            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka3").Data.Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Sari").Data.Id;
            car.ModelYear = Convert.ToDateTime("03.02.1988");
            car.DailyPrice = 8000;
            car.Description = "Araç üçün açıklaması";

            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka4").Data.Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Beyaz").Data.Id;
            car.ModelYear = Convert.ToDateTime("03.02.1988");
            car.DailyPrice = 8000;
            car.Description = "";

            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka5").Data.Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Siyah").Data.Id;
            car.ModelYear = Convert.ToDateTime("03.02.1988");
            car.DailyPrice = 0;
            car.Description = "Araç beşin açıklaması";

            carManager.AddOrEdit(car);


            foreach (CarDTO carDTO in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"Id: {carDTO.Id}, " +
                                  $"Marka Adı: {carDTO.BrandName}, " +
                                  $"Rengi: {carDTO.ColorName}, " +
                                  $"Renk Hex Kodu: {carDTO.ColorsHexCode}, " +
                                  $"Günlük Fiyatı: {carDTO.DailyPrice}, " +
                                  $"Açıklama: {carDTO.Description}, " +
                                  $"Model Yılı: {carDTO.ModelYear}\n");
            }
        }

        private static void Test(ColorManager colorManager, BrandManager brandManager, CarManager carManager)
        {
            Brand brand = new Brand
            {
                Id = 0,
                BrandName = "marka1",


            };
            brandManager.AddOrEdit(brand);

            brand.Id = 0;
            brand.BrandName = "marka1";

            brandManager.AddOrEdit(brand);


            brand.Id = 0;
            brand.BrandName = "marka2";


            
            brandManager.AddOrEdit(brand);
            
            Car car = new Car
            {
                Id = 0,
                BrandId = brandManager.Get(b => b.BrandName == "Marka1").Data.Id,
                ColorId = colorManager.Get(c => c.ColorName == "Siyah").Data.Id,
                ModelYear = Convert.ToDateTime("03.02.1999"),
                DailyPrice = 3700,
                Description = "Araç birin açıklaması"
            };
            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka2").Data.Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Kirmizi").Data.Id;
            car.ModelYear = Convert.ToDateTime("03.02.2000");
            car.DailyPrice = 4900;
            car.Description = "Araç ikinin açıklaması";

            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka3").Data.Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Sari").Data.Id;
            car.ModelYear = Convert.ToDateTime("03.02.1988");
            car.DailyPrice = 8000;
            car.Description = "Araç üçün açıklaması";

            carManager.AddOrEdit(car);

            var CarList = from c in carManager.GetAll().Data
                          join b in brandManager.GetAll().Data on c.BrandId equals b.Id
                          join clr in colorManager.GetAll().Data on c.ColorId equals clr.Id
                          select new CarDTO
                          {
                              Id = c.Id,
                              BrandName = b.BrandName,
                              ColorName = clr.ColorName,
                              ColorsHexCode = clr.HexCode,
                              DailyPrice = c.DailyPrice,
                              Description = c.Description,
                              ModelYear = c.ModelYear.Year
                          };

            foreach (CarDTO carDTO in CarList)
            {
                Console.WriteLine($"Id: {carDTO.Id}, " +
                    $"Marka Adı: {carDTO.BrandName}, " +
                    $"Rengi: {carDTO.ColorName}, " +
                    $"Renk Hex Kodu: {carDTO.ColorsHexCode}, " +
                    $"Günlük Fiyatı: {carDTO.DailyPrice}, " +
                    $"Açıklama: {carDTO.Description}, " +
                    $"Model Yılı: {carDTO.ModelYear}\n");
            }
        }
    }
}
