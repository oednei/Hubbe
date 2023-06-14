using Hubbe.Services.Restaurant.Domain.Entities;
using Hubbe.Services.Restaurant.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Hubbe.Services.Restaurant.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;

        public ReservationController(IReservationRepository reservationRepository, ITableRepository tableRepository)
        {
            this._reservationRepository = reservationRepository;
            this._tableRepository = tableRepository;
        }

        #region POST
        [HttpPost("Register")]
        public async Task<IActionResult> Register(string date, string time, string tableNumber, int numberOfPeople, string description)
        {
            if (string.IsNullOrEmpty(date) || string.IsNullOrEmpty(time) || string.IsNullOrEmpty(tableNumber))
                return BadRequest("Faltando parametros!");
            DateTime reservationDate = GetDateTime(date, time);

            ReservationEntity reservationEntity = new ReservationEntity()
            {
                ReservationDate = reservationDate,
                ReservationTime = reservationDate,
                RegisterDate = DateTime.Now,
                TableNumber = int.Parse(tableNumber),
                NumberOfClients = numberOfPeople,
                Description = description ?? string.Empty
            };

            List<TablesEntity> tables = _tableRepository.GetAll().Result.ToList();

            TablesEntity? tableEntity = tables.Where(t => t.Number == reservationEntity.TableNumber).FirstOrDefault();
            List<ReservationEntity> reservations = _reservationRepository.GetAll().Result.ToList();

            bool isNotAvailable = reservations.Where(r => r.TableNumber == int.Parse(tableNumber) && r.ReservationDate == reservationDate).Count() > 0;

            if (tableEntity == null)
                return BadRequest("A Mesa escolhida não existe!");

            if (isNotAvailable)
                return BadRequest("A mesa está com reserva para esse horário");

            await _reservationRepository.Insert(reservationEntity);

            return Ok("Registro com sucesso");
        }
        #endregion

        #region GET
        [HttpGet("ReservationList")]
        public async Task<IActionResult> ReservationList()
        {
            var allReservation = await _reservationRepository.GetAll();
            if (allReservation == null)
                return Ok("Não retornou nenhum registro!");

            List<ReservationEntity> reservations = allReservation.ToList();

            return Ok(reservations);
        }

        [HttpGet("ReservationListByDate")]
        public async Task<IActionResult> ReservationListByDate(string strReservationDate, string strReservationTime)
        {
            if (string.IsNullOrEmpty(strReservationDate) || string.IsNullOrEmpty(strReservationTime))
                return BadRequest("Faltando parametros!");

            DateTime reservationDate = GetDateTime(strReservationDate, strReservationTime);

            var allReservation = await _reservationRepository.GetAll();
            if (allReservation == null)
                return Ok("Não retornou nenhum registro!");

            List<ReservationEntity> reservations = allReservation.Where(r => r.ReservationDate == reservationDate).ToList();

            return Ok(reservations);
        }

        [HttpGet("ReservationListByTable")]
        public async Task<IActionResult> ReservationListByTableNumber(string tableNumber)
        {
            if (string.IsNullOrEmpty(tableNumber))
                return BadRequest("É preciso informar todos os dados!");

            var allReservation = await _reservationRepository.GetAll();
            if (allReservation == null)
                return Ok("Não retornou nenhum registro!");

            List<ReservationEntity> reservations = allReservation.Where(r => r.TableNumber == int.Parse(tableNumber)).ToList();

            return Ok(reservations);
        }

        [HttpGet("UpComingReservationList")]
        public async Task<IActionResult> ReservationListUpComing()
        {
            var allReservation = await _reservationRepository.GetAll();
            if (allReservation == null)
                return Ok("Não retornou nenhum registro!");

            List<ReservationEntity> reservations = allReservation.Where(r => r.ReservationDate > DateTime.Now).ToList();

            return Ok(reservations);
        }

        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetByReservationTimeAndDate(string strReservationDate, string strReservationTime)
        {
            if (string.IsNullOrEmpty(strReservationTime) || string.IsNullOrEmpty(strReservationDate))
                return BadRequest("Valor nulo!");

            var allReservations = await _reservationRepository.GetAll();

            List<ReservationEntity> reservations = allReservations.ToList();

            DateTime reservationDate = GetDateTime(strReservationDate, strReservationTime);

            List<ReservationEntity> reservationsOnPassedDate = reservations.Where(r => r.ReservationDate == reservationDate).ToList();

            List<TablesEntity> tables = (List<TablesEntity>)await _tableRepository.GetAll();

            tables = tables.Where(t => !reservationsOnPassedDate.Any(r => t.Number == r.TableNumber)).ToList();

            return Ok(new { Message = "As seguinte mesas estão disponíveis.", Total = tables.Count(), AvailableTables = tables });
        }
        #endregion

        #region DELETE
        [HttpDelete("ReservCancelation")]
        public async Task<IActionResult> ReservCancelation(string strReservationDate, string strReservationTime, string tableNumber)
        {
            if(string.IsNullOrEmpty(strReservationDate) || string.IsNullOrEmpty(strReservationTime) || string.IsNullOrEmpty(tableNumber))
                return BadRequest("É preciso informar todos os dados!");

            DateTime reservationDate = GetDateTime(strReservationDate, strReservationTime);

            var allReservations = await _reservationRepository.GetAll();

            if (allReservations == null)
                return BadRequest("Não foi encontrado nenhuma reserva na base de dados!");

            List<ReservationEntity> reservations = allReservations.ToList();

            if (reservations == null)
                return BadRequest("Não foi encontrado a reserva!");

            ReservationEntity? reservationEntity = reservations.Where(r => r.ReservationDate == reservationDate && r.TableNumber == int.Parse(tableNumber)).FirstOrDefault();

            if (reservationEntity == null)
                return BadRequest("Não foi encontrado a reserva com os dados especificados!");
            else
                await ReservCancelationById(reservationEntity.Id);

            return Ok("Reserva Cancelada com Sucesso!!");
        }

        [HttpDelete("ReservCancelationById")]
        public async Task<IActionResult> ReservCancelationById(int reservationID)
        {
            if (reservationID <= 0)
                return BadRequest("Registro não encontrado!");
            else 
            {
                await _reservationRepository.Delete(reservationID);
                return Ok();
            }
        }
        #endregion

        #region Methods
        private static DateTime GetDateTime(string date, string time)
        {
            return DateTime.Parse(string.Concat(date, " ", time));
        }

        #endregion
    }
}
