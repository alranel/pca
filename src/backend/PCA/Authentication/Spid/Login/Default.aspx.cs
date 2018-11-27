﻿/*
 * Licensed to Jasig under one or more contributor license
 * agreements. See the NOTICE file distributed with this work
 * for additional information regarding copyright ownership.
 * Jasig licenses this file to you under the Apache License,
 * Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a
 * copy of the License at:
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Web;
using System.Web.Security;
using DotNetCasClient;
using log4net;

namespace Authentication.Spid.Login
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                throw new System.ApplicationException("Current Session is null!");
            }

            string redirectUrl = null;
            if (CasAuthentication.ServiceTicketManager != null)
            {
                string serviceTicket = null;
                HttpCookie ticketCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (ticketCookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(ticketCookie.Value);
                    if (ticket != null)
                    {
                        CasAuthenticationTicket casTicket = CasAuthentication.ServiceTicketManager.GetTicket(ticket.UserData);
                        serviceTicket = casTicket.ServiceTicket;
                    }
                }
              
                if (serviceTicket != null)
                {
                    Session.Add("serviceTicket", serviceTicket);
                    log.Info("Save serviceTicket in Session (" + HttpContext.Current.Session.SessionID + ") -> [serviceTicket: " + serviceTicket + "]");
                    redirectUrl = CasAuthentication.CasClientUrl + "spid";
                }    
            }

            if(redirectUrl == null)
                redirectUrl = CasAuthentication.CasClientUrl;

            log.Info("Login Redirect to: " + redirectUrl);
            Response.Redirect(redirectUrl);

        }
    }
}