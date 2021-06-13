﻿using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[Route("identity")]
public class IdentityController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }

    [HttpGet]
    [Route("test")]
    public string Test()
    {
        return "elo, tu SALKA.DATA.EQUIPMENT";
    }
}