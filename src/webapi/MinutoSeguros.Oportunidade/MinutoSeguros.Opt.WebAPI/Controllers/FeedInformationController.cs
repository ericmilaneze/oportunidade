using JSend.WebApi;
using MinutoSeguros.Opt.Domain.Feeds;
using MinutoSeguros.Opt.Domain.Interfaces;
using MinutoSeguros.Opt.WebAPI.Helpers;
using MinutoSeguros.Opt.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MinutosSeguros.Opt.WebAPI.Controllers
{
  [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
  public class FeedInformationController : JSendApiController
  {
    private readonly IBlogPostWordCounterService _blogPostWordCounterService;
    private readonly IFeedTopTenWordsService _feedTopTenWordsService;
    private readonly IFeedReader _feedReader;

    public FeedInformationController(
      IBlogPostWordCounterService blogPostWordCounterService,
      IFeedTopTenWordsService feedTopTenWordsService,
      IFeedReader feedReader)
    {
      _blogPostWordCounterService = blogPostWordCounterService;
      _feedTopTenWordsService = feedTopTenWordsService;
      _feedReader = feedReader;
    }

    // GET: api/Feeds
    public IHttpActionResult Get()
    {
      try
      {
        Feed feed = _feedReader.GetFeed(ConfigHelper.GetFeedUrl(), ConfigHelper.GetFeedPostCount());

        var articlesAndPrepositions = ArticlesAndPrepositionsHelper.Get();

        FeedInformationModel feedInformationModel = new FeedInformationModel();
        feedInformationModel.TopTenWords = _feedTopTenWordsService.GetTopTen(feed, articlesAndPrepositions);
        feedInformationModel.WordCountPerPost = new List<WordCountPerPost>();

        foreach (var blogPost in feed.BlogPosts)
          feedInformationModel.WordCountPerPost.Add(new WordCountPerPost(
            postTitle: blogPost.Title,
            wordCount: _blogPostWordCounterService.GetWordCount(blogPost, articlesAndPrepositions)));

        return JSendOk(feedInformationModel);
      }
      catch (Exception ex)
      {
        return JSendError(HttpStatusCode.InternalServerError, "Ocorreu um erro no processamento.", data: ex.Message);
      }
    }
  }
}
