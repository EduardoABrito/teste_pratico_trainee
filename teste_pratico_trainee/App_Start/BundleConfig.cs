using System.Web;
using System.Web.Optimization;

namespace teste_pratico_trainee
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender com ela. Após isso, quando você estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.

            bundles.Add(new Bundle("~/bundles/Scripts/bootstrap").Include(
                      "~/Content/Shared/Scripts/bootstrap.min.js",
                      "~/Content/Shared/Scripts/Jquery/jquery.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Shared/Css/bootstrap.min.css",
                      "~/Content/Shared/Css/style.css"));

            bundles.Add(new Bundle("~/Content/Scripts/Marcaras").Include(
                      "~/Content/Shared/Scripts/Jquery/jquery.mask.js",
                      "~/Content/Shared/Scripts/Jquery/Mascaras.js"));

            bundles.Add(new StyleBundle("~/Content/Plugins/Css").Include(
                    "~/Content/Shared/Plugins/DateRangePicker/daterangepicker.css",
                    "~/Content/Shared/Plugins/SweetAlert/sweetalert2.min.css"));
                

            bundles.Add(new Bundle("~/Content/Plugins/Scripts").Include(
                    "~/Content/Shared/Plugins/DateRangePicker/moment.min.js",
                    "~/Content/Shared/Plugins/DateRangePicker/daterangepicker.js",
                    "~/Content/Shared/Plugins/SweetAlert/sweetalert2.js"));
                    
        }
    }
}
