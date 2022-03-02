﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shindan.Application.Cities.Commands.Create;
using Shindan.Application.Cities.Commands.Delete;
using Shindan.Application.Cities.Commands.Update;
using Shindan.Application.Cities.Queries.GetCities;
using Shindan.Application.Cities.Queries.GetCityById;
using Shindan.Application.Common.Models;
using Shindan.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shindan.Api.Controllers
{
    /// <summary>
    /// Cities
    /// </summary>
    [Authorize]
    public class CitiesController : BaseApiController
    {
        /// <summary>
        /// Get all cities
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<CityDto>>>> GetAllCities(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllCitiesQuery(), cancellationToken));
        }

        /// <summary>
        /// Get city by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<CityDto>>> GetCityById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCityByIdQuery { CityId = id }, cancellationToken));
        }

        /// <summary>
        /// Create city
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<CityDto>>> Create(CreateCityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Update city
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ServiceResult<CityDto>>> Update(UpdateCityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Delete city by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<CityDto>>> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteCityCommand { Id = id }, cancellationToken));
        }
    }
}