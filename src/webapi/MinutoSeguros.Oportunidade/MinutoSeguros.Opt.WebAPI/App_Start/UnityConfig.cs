using MinutoSeguros.Opt.Domain.Interfaces;
using MinutoSeguros.Opt.Domain.Services;
using MinutoSeguros.Opt.FeedReader;
using MinutoSeguros.Opt.FeedReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;
using Unity.Lifetime;

public class UnityConfig
{
  public static void Register(HttpConfiguration config)
  {
    var container = new UnityContainer();

    #region MinutoSeguros.Opt.Domain

    container.RegisterType<IBlogPostWordCounterService, BlogPostWordCounterService>(new HierarchicalLifetimeManager());
    container.RegisterType<IFeedReader, FeedReader>(new HierarchicalLifetimeManager());
    container.RegisterType<IFeedTopTenWordsService, FeedTopTenWordsService>(new HierarchicalLifetimeManager());
    container.RegisterType<IWordsRemovalService, WordsRemovalService>(new HierarchicalLifetimeManager());

    #endregion

    #region MinutoSeguros.Opt.FeedReader

    container.RegisterType<IHtmlContentReader, HtmlContentReader>(new HierarchicalLifetimeManager());
    container.RegisterType<ISyndicationFeedReader, SyndicationFeedReader>(new HierarchicalLifetimeManager());
    container.RegisterType<ISyndicationItemConverter, SyndicationItemConverter>(new HierarchicalLifetimeManager());
    container.RegisterType<ITextContentFromHtml, TextContentFromHtml>(new HierarchicalLifetimeManager());

    config.DependencyResolver = new UnityResolver(container);

    #endregion
  }
}