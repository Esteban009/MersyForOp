using System;
using System.Text;
using System.Web;

namespace Backend.Helpers
{
    public class Barcodecs
    {
        public string GenerateBarcode()
        {
            try
            {
                var charPool = "1-2-3-4-5-6-7-8-9-0".Split('-');
                var rs = new StringBuilder();
                var length = 6;
                var rnd = new Random();
                while (length-- > 0)
                {
                    var index = (int)(rnd.NextDouble() * charPool.Length);
                    if (charPool[index] != "-")
                    {
                        rs.Append(charPool[index]);
                        charPool[index] = "-";
                    }
                    else
                        length++;
                }
                return rs.ToString();
            }
            catch (Exception)
            {
                // ErrorLog.WriteErrorLog("Barcode", ex.ToString(), ex.Message);
            }
            return "";
        }

        //31 December 2012 Prapti

        public byte[] GetBarcodeImage(string barcode, string file)
        {
            var _barcode = new BarCode39();
            try
            {
                const int barSize = 16;
                var fontFile = HttpContext.Current.Server.MapPath("~/fonts/FREE3OF9.TTF");
                return (_barcode.Code39(barcode, barSize, true, file, fontFile));
            }
            catch (Exception)
            {
                //ErrorLog.WriteErrorLog("Barcode", ex.ToString(), ex.Message);
            }
            return null;
        }
    }
}
