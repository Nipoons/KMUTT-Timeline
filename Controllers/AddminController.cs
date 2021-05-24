using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kmutt_x_covid.Models;
using kmutt_x_covid.DBContext;
using Microsoft.EntityFrameworkCore;



namespace kmutt_x_covid.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ServerContext _serverContext;
        
        

        public AdminController(ILogger<AdminController> logger,ServerContext serverContext)
        {
            _logger = logger;
            _serverContext = serverContext;

        }
        [HttpGet]
        public IActionResult indexAdmin()
        {
            var joinTable = _serverContext.Users.Include(d => d.Risk).Include(r=> r.Position);
            return View(joinTable);
        }

        [HttpGet]  
        public IActionResult LoginAdmin()  
        {  var users = _serverContext.Users;
            return View(users);  
        }  
        
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public  IActionResult LoginAdmin(string username , string password)
        {
            var data = from i in _serverContext.Users.Include(i=>i.Risk) 
                            where i.Username == username && i.Password == password && i.PositionId == 1
                            select i;
            if(data==null)
            {
                return NotFound();
            }
        return RedirectToAction("IndexAdmin","Admin");
            
        }

        [HttpGet]  
        public IActionResult Detail(string id)  
        {  
            if(id==null)
            {
                return NotFound();
            }
            var users = _serverContext.Users.Include(r=>r.Risk).FirstOrDefault(m=>m.Id==id);
            if(users==null)
            {
                return NotFound();
            }
            return View(users);  
        }  

        [HttpGet]  
        public IActionResult Edit(string Id)  
        {  
            if(Id==null)
            {
                return NotFound();
            }
            var obj = _serverContext.Users.Find(Id);
            if(obj==null){
                return NotFound();
            }
            return View(obj);  
        }  

        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public IActionResult Edit(User users)  
        {  
            var user = _serverContext.Users.SingleOrDefault(o => o.Id == users.Id);
            var iduser= users.Id.ToString();
        
            var data_user1 = from i in _serverContext.BuildingStampIns.Include(i=>i.Building).Include(i => i.IdNavigation)
                            where i.IdNavigation.Id == iduser
                            select i;
            var data_user2 = from i in _serverContext.BuildingStampIns.Include(i=>i.Building).Include(i => i.IdNavigation)
                            where i.IdNavigation.Id != users.Id && i.IdNavigation.RiskId!=0
                            select i;

            var data_user4 = from i in _serverContext.BuildingStampIns.Include(i=>i.Building).Include(i => i.IdNavigation)
                            where i.IdNavigation.RiskId !=0 && i.IdNavigation.RiskId !=1
                            select i;
                        

            if(user != null)
            {
                    user.Id = users.Id;
                    user.Name = users.Name;
                    user.Phone = users.Phone;
                    user.Email = users.Email;
                    user.Department = users.Department;
                    user.RiskId = users.RiskId;
                    _serverContext.Users.Update(user);
                
                if(users.RiskId==0)
                {
                    var dataUser = _serverContext.BuildingStampIns.Include(u=>u.IdNavigation);
                    
                foreach(var i in data_user2.ToList()) 
                {
                    
                        foreach(var j in data_user1.ToList()) 
                        {
                            if(i.BuildingId == j.BuildingId && i.TimeIn.Date==j.TimeIn.Date && j.Floors==i.Floors) 
                            {
                                var obj=_serverContext.Users.Find(i.IdNavigation.Id);
                                obj.RiskId= 1;
                                _serverContext.Users.Update(obj);

                            }
                        
                        }
                
                }

                }
                else
                {

                }
                        _serverContext.SaveChanges(); 
            }
                TempData["Edit"]="Edit success!"; //sender value between controller with action

        return RedirectToAction("IndexAdmin","Admin");  
        }

        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public IActionResult Delete(User model)  
        {  
            var user = _serverContext.Users.Find(model.Id);
            _serverContext.Users.Remove(user);
            _serverContext.SaveChanges(); // commit to database

        return RedirectToAction("IndexAdmin","Admin");  
        }

        [HttpGet]
        public IActionResult TimelineAdmin()
        {
            var joinTable = _serverContext.BuildingStampIns.Include(u => u.IdNavigation).Include(b => b.Building);
            
            
            return View(joinTable);
        }
        [HttpPost]  
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> TimelineAdmin(string id){
            var data = from m in _serverContext.BuildingStampIns.Include(b =>b.Building).Include(u=>u.IdNavigation)           
                        select m;

                if (!String.IsNullOrEmpty(id))
                {
                    data = data.Where(s => s.Id.Contains(id));
                }
                foreach(var item in data){
                    ViewBag.n=item.IdNavigation.Name;
                    ViewBag.id=item.Id;
                        }
            return View(await data.ToListAsync());
        }

        public IActionResult InfectionAdmin()
        {

            var data = from m in _serverContext.BuildingStampIns.Include(b =>b.Building).Include(u=>u.IdNavigation)
                        where m.IdNavigation.RiskId==0
                        select m;
            var infect = from i in _serverContext.Infections
                        
                        select new {date=i.TimeInfection};
            
            foreach (var item in infect)
            {
                var test = item.date.AddDays(-1);
                data=data.Where(i=> i.TimeIn > item.date.AddDays(-14)&&i.TimeIn < item.date);
                
            }

            return View(data.ToList());
        }



    }
}