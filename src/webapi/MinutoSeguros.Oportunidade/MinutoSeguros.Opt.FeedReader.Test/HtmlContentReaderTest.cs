using System;
using System.ServiceModel.Syndication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Text;
using System.IO;
using System.Reflection;
using MinutoSeguros.Opt.FeedReader.Test.Helpers;

namespace MinutoSeguros.Opt.FeedReader.Test
{
  [TestClass]
  public class HtmlContentReaderTest
  {
    [TestMethod]
    [DeploymentItem(@"Files\feed.xml")]
    public void ReadHtmlContent()
    {
      HtmlContentReader htmlContentReader = new HtmlContentReader();

      string expectedContent = "<p><a href=\"http://blogminuto.azurewebsites.net/wp-content/uploads/2015/05/dia-do-seguro-thumb.jpg\"><img class=\"alignright  wp-image-14511\" src=\"http://blogminuto.azurewebsites.net/wp-content/uploads/2015/05/dia-do-seguro-thumb.jpg\" alt=\"Dia do Seguro\" width=\"257\" height=\"183\" /></a>14 de Maio é uma data que há mais de 50 anos está marcada como <strong>Dia do Seguro</strong>, ao menos para todos os países da América e na Espanha. O marco é uma homenagem à primeira Conferência Hemisférica de Seguros, realizada em 1946, em Nova York.</p>\n<p>Dois anos depois, a segunda edição do evento aconteceu no México e, entre os assuntos discutidos, fixou-se 14 de Maio como o Dia Continental do Seguro e foi criada a Fides, Federação Interamericana de Seguros.</p>\n<p>As comemorações do Dia do Seguro são simbólicas e servem para chamar a atenção para a importância desse produto que, ao longo dos anos, foi evoluindo para levar ainda mais proteção e tranquilidade aos consumidores.</p>\n<h2><strong>História do Seguro</strong></h2>\n<p>O conceito de indenizar um bem é bastante antigo. Temos como os primeiros registros da prática registros de 3000 a 2000 anos a.C, onde pastores caldeus montaram uma espécie de cooperativa para repor o gado perdido do seu povo. No mesmo período, babilônios firmavam convênios antes das caravanas no deserto para garantir o pagamento de novos camelos para aqueles perdessem seus animais no trajeto.</p>\n<p>Em 1600 a.C, os fenícios avançaram na prática ao criar convenções que ofereciam novos barcos aos navegadores que sofressem com problemas no mar. Enfim, ao longo dos anos, diversos exemplos surgiram.</p>\n<p>A primeira legislação, de fato, sobre seguros é datada de 1318 com a publicação da Ordenança de Pisa, na Itália. O primeiro contrato (apólice) foi feito em 1347 e protegia os bens de um navegador que faria o transporte de mercadorias entre Gênova até a Ilha de Mallorca, na Espanha.</p>\n<p>Os seguros evoluíram, portanto, na parte marítima. A primeira “apólice terrestre” surgiu apenas em 1488. Foi assinada em Florença para o rei Fernando I e garantia a indenização de uma coroa preciosa, já que a original seria transportada até Nápoles.</p>\n<p>Em 1583 surgiu o primeiro seguro de vida, feito por William Gybbons, um empresário de Londres. Foi emitido para 16 mercadorias pertencentes à Câmara de Seguros.</p>\n<p>Como podemos observar, os seguros estão presentes em nossas vidas desde muito tempo. Neste Dia do Seguro, vale o reforço de que estar protegido é sempre muito importante.</p>\n<p>A Minuto Seguros faz sua parte e celebra essa data especial!</p>\n<p>The post <a rel=\"nofollow\" href=\"http://blogminuto.azurewebsites.net/seguros/dia-do-seguro-conheca-historia/\">Dia do Seguro: conheça sua história</a> appeared first on <a rel=\"nofollow\" href=\"http://blogminuto.azurewebsites.net\">Blog Minuto</a>.</p>\n<div class='yarpp-related-rss yarpp-related-none'>\n<p>No related posts.</p>\n</div>\n";

      string content = htmlContentReader.GetHtmlContent(SyndicationFeedHelper.GetSyndicationItem(0));

      Assert.AreEqual(expectedContent, content);
    }

    [TestMethod]
    public void ReadHtmlContentPassingNull()
    {
      HtmlContentReader htmlContentReader = new HtmlContentReader();

      string content = htmlContentReader.GetHtmlContent(null);

      Assert.IsNull(content);
    }
  }
}
