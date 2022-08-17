﻿global using System;
global using System.Net.Mime;
global using System.Reflection;
global using System.Text.Json.Serialization;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using GestioneSagre.Categorie.CommandStack;
global using GestioneSagre.Categorie.QueryStack;
global using GestioneSagre.Categorie.Validators;
global using GestioneSagre.Core.Customizations.ServiceCollection;
global using GestioneSagre.Core.Models.Options;
global using GestioneSagre.Domain.Services.Application;
global using GestioneSagre.Domain.Services.Infrastructure;
global using GestioneSagre.Internal.QueryStack;
global using GestioneSagre.Internal.Validators.EmailSender;
global using GestioneSagre.Models.InputModels.Versione;
global using GestioneSagre.Models.InputSender;
global using GestioneSagre.Models.ViewModels;
global using GestioneSagre.Versioni.CommandStack;
global using GestioneSagre.Versioni.QueryStack;
global using GestioneSagre.Versioni.Validators.Versione;
global using GestioneSagre.Web.Server.Controllers.Common;
global using MailKit.Security;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Server.Kestrel.Core;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
