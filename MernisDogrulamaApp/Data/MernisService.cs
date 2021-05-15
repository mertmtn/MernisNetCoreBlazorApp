using System; 
using System.Threading.Tasks;
using static Mernis.KPSPublicSoapClient;

namespace MernisDogrulamaApp.Data
{
    public class MernisService
    {
        public Task<bool> TcKimlikDogrula(Kullanici kullanici)
        {
            bool dogrulamaSonucu = false;
            try
            {
                var mernisClient = new Mernis.KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap);
                var tcKimlikDogrulamaServisResponse = mernisClient.TCKimlikNoDogrulaAsync(long.Parse(kullanici.TcKimlikNo), kullanici.Ad, kullanici.Soyad, kullanici.DogumTarihi.Year).GetAwaiter().GetResult();
                dogrulamaSonucu = tcKimlikDogrulamaServisResponse.Body.TCKimlikNoDogrulaResult;
            }
            catch (Exception ex)
            {
                dogrulamaSonucu = false;
            }
            return Task.FromResult(dogrulamaSonucu);
        }
    }
}
