﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class LibraryBaseController : ControllerBase
{
}
