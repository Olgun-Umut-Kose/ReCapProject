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

            EFColorDal eFColorDal = new EFColorDal();
            EFBrandDal eFBrandDal = new EFBrandDal();
            EFCarDal eFCarDal = new EFCarDal();

            ColorManager colorManager = new ColorManager(eFColorDal);
            BrandManager brandManager = new BrandManager(eFBrandDal);
            CarManager carManager = new CarManager(eFCarDal);
            //Test(colorManager, brandManager, carManager);
            Car car = new Car
            {
                Id = 0,
                BrandId = brandManager.Get(b => b.BrandName == "Marka1").Id,
                ColorId = colorManager.Get(c => c.ColorName == "Siyah").Id,
                ModelYear = Convert.ToDateTime("03.02.1999"),
                DailyPrice = 3700,
                Description = "Araç birin açıklaması"
            };
            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka2").Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Kirmizi").Id;
            car.ModelYear = Convert.ToDateTime("03.02.2000");
            car.DailyPrice = 4900;
            car.Description = "Araç ikinin açıklaması";

            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka3").Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Sari").Id;
            car.ModelYear = Convert.ToDateTime("03.02.1988");
            car.DailyPrice = 8000;
            car.Description = "Araç üçün açıklaması";

            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka4").Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Beyaz").Id;
            car.ModelYear = Convert.ToDateTime("03.02.1988");
            car.DailyPrice = 8000;
            car.Description = "";

            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka5").Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Siyah").Id;
            car.ModelYear = Convert.ToDateTime("03.02.1988");
            car.DailyPrice = 0;
            car.Description = "Araç beşin açıklaması";

            carManager.AddOrEdit(car);

            
            foreach (CarDTO carDTO in carManager.GetCarDetails())
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
                BrandId = brandManager.Get(b => b.BrandName == "Marka1").Id,
                ColorId = colorManager.Get(c => c.ColorName == "Siyah").Id,
                ModelYear = Convert.ToDateTime("03.02.1999"),
                DailyPrice = 3700,
                Description = "Araç birin açıklaması"
            };
            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka2").Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Kirmizi").Id;
            car.ModelYear = Convert.ToDateTime("03.02.2000");
            car.DailyPrice = 4900;
            car.Description = "Araç ikinin açıklaması";

            carManager.AddOrEdit(car);

            car.Id = 0;
            car.BrandId = brandManager.Get(b => b.BrandName == "Marka3").Id;
            car.ColorId = colorManager.Get(c => c.ColorName == "Sari").Id;
            car.ModelYear = Convert.ToDateTime("03.02.1988");
            car.DailyPrice = 8000;
            car.Description = "Araç üçün açıklaması";

            carManager.AddOrEdit(car);

            var CarList = from c in carManager.GetAll()
                          join b in brandManager.GetAll() on c.BrandId equals b.Id
                          join clr in colorManager.GetAll() on c.ColorId equals clr.Id
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
