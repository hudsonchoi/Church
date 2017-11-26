<%@ Application Language="C#" %>

<script RunAt="server">

  void Application_Start(object sender, EventArgs e)
  {
    // Code that runs on application startup
      this.BeginRequest += new EventHandler(global_asax_BeginRequest);
  }

  void Application_End(object sender, EventArgs e)
  {
    //  Code that runs on application shutdown

  }
  void global_asax_BeginRequest(object sender, EventArgs e)
  {
      this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
      Page p = HttpContext.Current.Handler as Page;
      if (null != p)
          p.Title = "NJ Chodae Chruch";
  }

  void Application_Error(object sender, EventArgs e)
  {
     
  }

  void Session_Start(object sender, EventArgs e)
  {
    // Code that runs when a new session is started

  }

  void Session_End(object sender, EventArgs e)
  {
    // Code that runs when a session ends. 
    // Note: The Session_End event is raised only when the sessionstate mode
    // is set to InProc in the Web.config file. If session mode is set to StateServer 
    // or SQLServer, the event is not raised.

  }

  protected void Application_AuthenticateRequest(object sender, EventArgs e)
  {

  }

  protected void Application_AcquireRequestState(
    object sender, EventArgs e)
  {
      if (Dothan.ApplicationContext.AuthenticationType == "Windows") 
      return;

    System.Security.Principal.IPrincipal principal;
    try
    {
      principal = (System.Security.Principal.IPrincipal)
        HttpContext.Current.Session["DothanPrincipal"];
    }
    catch
    {
      principal = null;
    }

    if (principal == null)
    {
      // didn't get a principal from Session, so
      // set it to an unauthenticted PTPrincipal
      Dothan.Library.Security.PTPrincipal.Logout();
    }
    else
    {
      // use the principal from Session
      Dothan.ApplicationContext.User = principal;
    }
  }

</script>
