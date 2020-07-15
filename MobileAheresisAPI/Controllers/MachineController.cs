using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.Domain.TreatmentRecords;
using CRM.Services.Common;
using CRM.Services.Common.StoreProcedureServices;
using CRM.Services.Equipments;
using CRM.Services.TreatmentRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAheresisAPI.Models.Result;
using MobileAheresisAPI.Models.TreatmentRecords;
using MobileAheresisAPI.Utils;

namespace MobileAheresisAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {

        #region Fields
        private readonly ITreatmentRecordServices _treatmentRecordsServices;
        private readonly IEquipmentServices _equipmentServices;
        private readonly IReportService _reportService;
        #endregion

        #region CTOR
        public MachineController(ITreatmentRecordServices TreatmentRecordServices,
            IEquipmentServices EquipmentServices,
            IReportService ReportService)
        {
            this._treatmentRecordsServices = TreatmentRecordServices;
            this._equipmentServices = EquipmentServices;
            this._reportService = ReportService;
        }
        #endregion

        #region Get Master
        [HttpGet("GetMachineMaster")]
        //[Route("GetMachineMaster")]
        public ActionResult GetMachineMaster()
        {
            ResultModel resultModel = new ResultModel();
            var model = new MachineDropDown();

            var equipmentInfo = _equipmentServices.GetAllEquiipmentInfo();
          
         
            var EquipmentData = equipmentInfo.Select(a =>
            new EquipmentModel
            {
                CreatedOn = a.CreatedOn,
                Deleted = a.Deleted,
                Id = a.Id,
               MachineName = a.MachineName,

                SerialNo = a.SerialNo,
                LastUpdated = a.LastUpdated
            });

            model.equipmentList = EquipmentData.ToList();
           


            if (model != null)
            {
                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = model;
                return Ok(resultModel);
            }
            else
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = null;
                return Ok(resultModel);
            }
        }
        #endregion
        // GET: Machine/Details/5
        public ActionResult Details(int id)
        {
            return Ok();
        }

        // GET: Machine/Create
        public ActionResult Create()
        {
            return Ok();
        }

        // POST: Machine/Create
        [HttpPost("Create")]
        public ActionResult Create(MachineModel model)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                if (model.Id == 0)
                {
                    var machineData = new MachineMaster();

                    machineData.EquipmentId = model.EquipmentId;

                    machineData.EquipSerial = model.EquipSerial;

      machineData.KitTypeId = model.KitTypeId;

                
                    machineData.KitTypeSerial = model.KitTypeSerial;
      machineData.PMDate = model.PMDate;
                    machineData.ExpDate = model.ExpDate;
                    machineData.SafetyChkDate = model.SafetyChkDate;

                    machineData.MachineClean = model.MachineClean;

                    machineData.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                    machineData.AlarmCheck = model.AlarmCheck;

                    machineData.CorrectiveAction = model.CorrectiveAction;

                    machineData.PrimeSuccess = model.PrimeSuccess;
                    machineData.CleanedTrackDoors = model.CleanedTrackDoors;
                    machineData.CleanedSensors = model.CleanedSensors;
                    machineData.CleanedPressurePODSSeals = model.CleanedPressurePODSSeals;
                    machineData.CleanedFrontDoorSensors = model.CleanedFrontDoorSensors;
                    machineData.CreatedOn = DateTime.UtcNow;
                    machineData.LastUpdated = DateTime.UtcNow;
                    machineData.Deleted = false;
                    //Mark Complete
                    machineData.MarkComplete = model.MarkComplete;

                    _treatmentRecordsServices.InsertMachineInfo(machineData);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)machineData.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    //model response
                    model.Id = machineData.Id;
                    model.TreatmentRecordMasterId = machineData.TreatmentRecordMasterId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
                else
                {
                    var machineData = _treatmentRecordsServices.GetMachineInfoById(model.Id);
                    machineData.Id = model.Id;
                    machineData.EquipmentId = model.EquipmentId;

                    machineData.EquipSerial = model.EquipSerial;

                    machineData.KitTypeId = model.KitTypeId;
                    machineData.TreatmentRecordMasterId = model.TreatmentRecordMasterId;
                  
                    machineData.KitTypeSerial = model.KitTypeSerial;
                    machineData.PMDate = model.PMDate;
                    machineData.ExpDate = model.ExpDate;
                    machineData.SafetyChkDate = model.SafetyChkDate;

                    machineData.MachineClean = model.MachineClean;


                    machineData.AlarmCheck = model.AlarmCheck;

                    machineData.CorrectiveAction = model.CorrectiveAction;

                    machineData.PrimeSuccess = model.PrimeSuccess;
                    machineData.CleanedTrackDoors = model.CleanedTrackDoors;
                    machineData.CleanedSensors = model.CleanedSensors;
                    machineData.CleanedPressurePODSSeals = model.CleanedPressurePODSSeals;
                    machineData.CleanedFrontDoorSensors = model.CleanedFrontDoorSensors;

                    machineData.MarkComplete = model.MarkComplete;
                    machineData.LastUpdated = DateTime.UtcNow;
                   
                    _treatmentRecordsServices.UpdateMachineInfo(machineData);
                    //Bhawana(09/10/2019)
                    //Change treatment Record Status
                    _reportService.UpdateTreatmentStatusID((int)machineData.TreatmentRecordMasterId);
                    //12/10/19 aakansha
                    //model response
                    model.Id = machineData.Id;
                    model.TreatmentRecordMasterId = machineData.TreatmentRecordMasterId;
                    resultModel.Message = ValidationMessages.Success;
                    resultModel.Status = 1;
                    resultModel.Response = model;
                    return Ok(resultModel);
                }
            }
            catch(Exception e)
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = null;
                return Ok(resultModel);
            }
        }


        // GET: Doctor/GetById/5
        [HttpGet("GetById")]
        public ActionResult GetById(int Id)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
               
                var machineData = new MachineModel();
                var MachineData = _treatmentRecordsServices.GetMachineInfoById(Id);
                machineData.Id = MachineData.Id;
                machineData.EquipmentId = MachineData.EquipmentId;

                machineData.EquipSerial = MachineData.EquipSerial;

                machineData.KitTypeId = (int)MachineData.KitTypeId;
                machineData.TreatmentRecordMasterId = MachineData.TreatmentRecordMasterId;
               
                machineData.KitTypeSerial = MachineData.KitTypeSerial;
                machineData.PMDate = MachineData.PMDate;
                machineData.ExpDate = MachineData.ExpDate;
                machineData.SafetyChkDate = MachineData.SafetyChkDate;

                machineData.MachineClean = MachineData.MachineClean;


                machineData.AlarmCheck = MachineData.AlarmCheck;

                machineData.CorrectiveAction = MachineData.CorrectiveAction;

                machineData.PrimeSuccess = MachineData.PrimeSuccess;
                machineData.CleanedTrackDoors = MachineData.CleanedTrackDoors;
                machineData.CleanedSensors = MachineData.CleanedSensors;
                machineData.CleanedPressurePODSSeals = MachineData.CleanedPressurePODSSeals;
                machineData.CleanedFrontDoorSensors = MachineData.CleanedFrontDoorSensors;

                machineData.CreatedOn = MachineData.CreatedOn;
                machineData.LastUpdated = MachineData.LastUpdated;
                machineData.Deleted = MachineData.Deleted;
                resultModel.Message = ValidationMessages.Success;
                resultModel.Status = 1;
                resultModel.Response = machineData;
                return Ok(resultModel);
            }
            catch (Exception e)
            {
                resultModel.Message = ValidationMessages.Failure;
                resultModel.Status = 0;
                resultModel.Response = null;
                return Ok(resultModel);
            }
        }

        // GET: Machine/Edit/5
        public ActionResult Edit(int id)
        {
            return Ok();
        }

        // POST: Machine/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return Ok();
            }
            catch
            {
                return Ok();
            }
        }

        // GET: Machine/Delete/5
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        // POST: Machine/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return Ok();
            }
            catch
            {
                return Ok();
            }
        }
    }
}