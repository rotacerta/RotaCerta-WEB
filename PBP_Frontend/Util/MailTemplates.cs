namespace PBP_Frontend.Util
{
    public class MailTemplates
    {
        public static string GetRegisterMailSubject()
        {
            return "Confirmar conta -PickByPath";
        }

        public static string GetRegisterMailTemplate(string callbackUrl)
        {
            string template = "<!DOCTYPE html>" +
                                "<html>" +
                                "<head>" +
                                    "<title>Confirmar sua conta</title>" +
                                    "<style type=\"text/css\"> " +
                                        "*{ margin: 0; padding: 0; }" +
                                        "body{ padding: 1rem; display: block; background-color: rgb(255, 255, 255); font-family: Arial, Helvetica, sans-serif; color: rgb(0, 0, 0); }" +
                                        ".mail-content{ margin: auto; height: 75%; width: 50%; }" +
                                        ".center{ width: 100%; text-align: center; }" +
                                        ".bolder{ font-weight: 700; }" +
                                        ".logo{ font-size: 25pt; margin-top: 3rem; }" +
                                        ".orange{ color: rgb(237, 124, 49)!important; }" +
                                        ".mt-15{ margin-top: 1.5rem; }" +
                                        ".mt-10{ margin-top: 1rem; }" +
                                        ".mail-title{ margin-top: 3rem; }" +
                                        ".content-text-title{ margin-top: 3rem; }" +
                                        ".link{ text-decoration: none; }" +
                                        ".footer{ font-size: 10pt; padding: .5rem; background-color: rgb(222, 219, 222); }" +
                                    "</style>" +
                                "</head>" +
                                "<body>" +
                                    "<div class=\"mail-content\">" +
                                        "<div class=\"logo center bolder\"><span class=\"orange\">P</span>ick<span class=\"orange\">B</span>y<span class=\"orange\">P</span>ath</div>" +
                                        "<h3 class=\"mail-title\">Confirmar conta</h3>" +
                                        "<p class=\"content-text-title\">Olá, seja bem-vindo ao PickByPath!</p>" +
                                        "<p class=\"content-text-body mt-15\">Confirme sua conta clicando <a class=\"link bolder orange\" href=\"" + callbackUrl + "\">aqui</a></p>" +
                                        "<p class=\"orange mt-15\">Equipe PickByPath.</p>" +
                                        "<div class=\"footer mt-10\">" +
                                            "Grupo Eras - PickByPath -  <script type=\"text/javascript\"> date = new Date(); year = date.getFullYear(); document.write(year); </script>" +
                                        "</div>" +
                                    "</div>" +
                                "</body>" +
                                "</html>";
            return template;
        }
    }
}