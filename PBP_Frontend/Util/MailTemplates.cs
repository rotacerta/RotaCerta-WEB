namespace PBP_Frontend.Util
{
    public class MailTemplates
    {
        private static string GetBaseCSS()
        {
            return "*{margin:0;padding:0}body{padding:1rem;display:block;background-color:#fff;font-family:Arial,Helvetica,sans-serif}.mail-content{margin:auto;height:75%;width:55%}.center{width:100%;text-align:center}.bolder{font-weight:700}.logo{font-size:25pt;margin-top:3rem}.orange{color:#ed7c31!important}.mt-15{margin-top:1.5rem}.mt-10{margin-top:1rem}.mail-title{margin-top:3rem}.content-text-title{margin-top:3rem}.link{text-decoration:none}.footer{font-size:10pt;padding:.5rem;background-color:#dedbde}@media screen and (max-width:900px){.mail-content{width:90%!important}}";
        }

        private static string GetBaseHTML(string mailTitle, string mailContent)
        {
            return string.Format("<!DOCTYPE html><html lang=\"pt-br\"><head><meta charset=\"utf-8\"><title>{0}</title><style type=\"text/css\">{1}</style></head><body><div class=\"mail-content\"><div class=\"logo center bolder\"><span class=\"orange\">P</span>ick<span class=\"orange\">B</span>y<span class=\"orange\">P</span>ath</div>{2}<p class=\"orange mt-15\">Equipe PickByPath.</p><div class=\"footer mt-10\">Grupo Eras - PickByPath - <script type=\"text/javascript\">hoje=new Date();ano=hoje.getFullYear();document.write(ano);</script></div></div></body></html>", mailTitle, GetBaseCSS(), mailContent);
        }

        public static string GetRegisterMailSubject()
        {
            return "Confirmar conta - PickByPath";
        }

        public static string GetRegisterMailTemplate(string callbackUrl)
        {
            string content = string.Format("<h3 class=\"mail-title\">Confirmar conta</h3><p class=\"content-text-title\">Olá, seja bem-vindo ao PickByPath!</p><p class=\"content-text-body mt-15\">Confirme sua conta clicando <a class=\"link bolder orange\" href=\"{0}\">aqui</a></p>", callbackUrl);
            return GetBaseHTML("Confirmar conta", content);
        }

        public static string GetForgotPassMailSubject()
        {
            return "Confirmar conta - PickByPath";
        }

        public static string GetForgotPassMailTemplate(string callbackUrl)
        {
            string content = string.Format("<h3 class=\"mail-title\">Redefinir senha</h3><p class=\"content-text-title\">Olá!</p><p class=\"content-text-body mt-15\">Alguém solicitou recentemente uma alteração na senha da sua conta do PickByPath. Se foi você, então defina sua nova senha aqui:</p><p class=\"content-text-body mt-15\"><a class=\"link bolder orange\" href=\"{0}\">Redefinir senha.</a></p>", callbackUrl);
            return GetBaseHTML("Redefinir senha", content);
        }
    }
}