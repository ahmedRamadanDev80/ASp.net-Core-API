﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;
using WebApp.Models;
using WebApp.Models.Dto;
using WebApp.Models.VM;
using WebApp.Services;
using WebApp.Services.IServices;
using WebApp_Utility;

namespace WebApp.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper, IVillaService villaService)
        {
            _villaNumberService = villaNumberService;
            _mapper = mapper;
            _villaService = villaService;
        }
        public async Task<IActionResult> Index()
        {
            List<VillaNumberDTO> list = new();

            var response = await _villaNumberService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberVM = new();
            var response = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                villaNumberVM.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(villaNumberVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _villaNumberService.CreateAsync<APIResponse>(model.VillaNumber, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "VillaNumber created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // display the error 
                    if(response.ErrorMessages.Count > 0) 
                    { ModelState.AddModelError("ErrorMessages",response.ErrorMessages.FirstOrDefault()); }
                }
            }
            // in case of an error refill the text boxes with villa data again
            var resp = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); ;
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> UpdateVillaNumber(int VillaNo)
        {
            VillaNumberUpdateVM villaNumberVM = new();
            var response = await _villaNumberService.GetAsync<APIResponse>(VillaNo, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                VillaNumberDTO model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                villaNumberVM.VillaNumber = _mapper.Map<VillaNumberUpdateDTO>(model);
            }

            response = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                villaNumberVM.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
                return View(villaNumberVM);
            }


            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _villaNumberService.UpdateAsync<APIResponse>(model.VillaNumber, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "VillaNumber updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var resp = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); ;
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteVillaNumber(int VillaNo)
        {
            VillaNumberDeleteVM villaNumberVM = new();
            var response = await _villaNumberService.GetAsync<APIResponse>(VillaNo, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                VillaNumberDTO model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                villaNumberVM.VillaNumber = model;
            }

            response = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                villaNumberVM.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
                return View(villaNumberVM);
            }


            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteVM model)
        {

            var response = await _villaNumberService.DeleteAsync<APIResponse>(model.VillaNumber.VillaNo, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "VillaNumber Deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
    }
}
