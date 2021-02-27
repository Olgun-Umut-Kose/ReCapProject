using System;
using System.IO;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static IDataResult<string> Save(IFormFile file, string type)
        {
            try
            {
                if (file.Length > 0)
                {
                    var creatorResult = PathCreator(file, type);


                    if (!CheckDirectoryExists(creatorResult.klasorYolu))
                    {
                        Directory.CreateDirectory(creatorResult.klasorYolu);
                    }


                    using (FileStream fs = System.IO.File.Create(creatorResult.dosyaYolu))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }

                    return new SuccessDataResult<string>(creatorResult.dosyaYolu);
                }

                return new ErrorDataResult<string>(null);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<string>(e.Message, null);
            }
            
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
                return new SuccessResult("Başarılı");
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
            
        }

        private static bool CheckDirectoryExists(string klasorYolu)
        {
            return Directory.Exists(klasorYolu);
        }

        private static (string dosyaAdi, string klasorYolu, string dosyaYolu) PathCreator(IFormFile file, string type)
        {
            string uzanti = Path.GetExtension(file.FileName);
            string dosyaAdi = Guid.NewGuid().ToString("D") + uzanti;
            string klasorYolu = Path.Combine(Environment.CurrentDirectory, @"wwwroot\Images");
            string dosyaYolu = Path.Combine(klasorYolu, dosyaAdi);
            return (dosyaAdi, klasorYolu, dosyaYolu);
        }
    }
}