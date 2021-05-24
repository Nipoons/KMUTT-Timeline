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
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ServerContext _serverContext;
        
        

        public UserController(ILogger<UserController> logger,ServerContext serverContext)
        {
            _logger = logger;
            _serverContext = serverContext;

        }

          [HttpGet]
        public IActionResult indexUser()
        {
            var id = TempData["id"].ToString();
            TempData.Keep();
            var data_user = from j in _serverContext.Users.Include(r=>r.Risk) 
                            where j.Id==id 
                            select j;
            var data_obj = from m in _serverContext.BuildingStampIns.Include(b =>b.Building).Include(u=>u.IdNavigation)           
                            where m.IdNavigation.Id == id
                            select m;
            
            foreach(var i in data_user)
            {
                ViewBag.n=i.Name;
                ViewBag.id=i.Id;
                ViewBag.phone=i.Phone;
                ViewBag.risk=i.Risk.RiskLevel;
                ViewBag.email = i.Email;
                
            }
            return View(data_obj);
        }


        [HttpGet]  
    public IActionResult LoginUser()  
    {  var users = _serverContext.Users;

        return View(users);  
    }  
        
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public  IActionResult LoginUser(string username , string password)
        {
            var data_check = from i in _serverContext.Users.Include(i=>i.Risk) 
                            where i.Username == username && i.Password == password 
                            select new {name=i.Name,
                                        id=i.Id,
                                        userId=i.Username, 
                                        password=i.Password,
                                        email = i.Email,
                                        phone = i.Phone,
                                        risk = i.Risk.RiskLevel,
                                        position = i.Position};
            var data = from m in _serverContext.BuildingStampIns.Include(b =>b.Building).Include(u=>u.IdNavigation)           
                        select m;
            var check = data_check.SingleOrDefault();
            
            if(check==null)
            {
                return NotFound();
            }

            foreach(var data1 in data_check)
            {
                TempData["name"] = data1.name;
                TempData["id"] = data1.id;
                TempData["Email"] = data1.email;
                TempData["Phone"]=data1.phone;
                TempData["Risk"]=data1.risk;
                ViewBag.id=data1.id;
                data = from j in data 
                    where j.IdNavigation.Id == data1.id
                    select j;
                
            }
        return RedirectToAction("IndexUser","User");
            
        }


         [HttpGet]  
        public IActionResult Create()  
        {  
            return View();  
        }  

    [HttpPost]  
    [ValidateAntiForgeryToken]  
    public IActionResult Create([Bind] User users)  
    {  
            if (ModelState.IsValid)  
            {  
                _serverContext.Users.Add(users);
                _serverContext.SaveChanges(); // commit to database
                TempData["Message"]="Thank you!"; //sender value between controller with action

            }  

        return RedirectToAction("LoginUser");  
    }

        
      

         [HttpGet]
        public IActionResult DetailUser(){
            var id = TempData["id"].ToString();
            TempData.Keep();
            var data = from m in _serverContext.Users.Include(data=>data.Risk) 
                        where m.Id == id
                        select m;

                
                foreach(var item in data)
                {
                    ViewBag.n=item.Name;
                    ViewBag.id=item.Id;
                    ViewBag.phone=item.Phone;
                    ViewBag.risk=item.Risk.RiskLevel;
                    ViewBag.email = item.Email;
                    ViewBag.Username =item.Username;
                    ViewBag.Password =item.Password; 
                }
            return View(data);
        }

      

[HttpGet]  
        public IActionResult EditUser(string Id)  
        {  
            
            if(Id==null)
            {
                return NotFound();
            }
            var obj = _serverContext.Users.Find(Id);
            var data = _serverContext.Users.Where(i=>i.Name == Id);
            
            if(obj==null){
                return NotFound();
            }
            foreach (var item in data)
            {
                ViewBag.n = item.Name;
                
            }
            return View(obj);  
        }  

        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public IActionResult EditUser(User users)  
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
        return RedirectToAction("IndexUser","User");  
        }
        
        
       

        
       


        


        [HttpGet]
        public IActionResult Timeline()
        {
            var joinTable = _serverContext.BuildingStampIns.Include(u => u.IdNavigation).Include(b => b.Building);
            
            
            return View(joinTable);
        }
        [HttpPost]  
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Timeline(string id){
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

        public IActionResult Infection()
        {
            ViewBag.n = TempData["name"].ToString();
            TempData.Keep();

            var data = from m in _serverContext.BuildingStampIns.Include(b =>b.Building).Include(u=>u.IdNavigation)
                        where m.IdNavigation.RiskId==0
                        select m;
            var infect = from i in _serverContext.Infections
                        
                        select new {date=i.TimeInfection};
            
            foreach (var item in infect)
            {
                var test = item.date.AddDays(-1);
                Console.WriteLine(test);
                data=data.Where(i=> i.TimeIn > item.date.AddDays(-14)&&i.TimeIn < item.date);
                
            }

            return View(data.ToList());
        }

       

       
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
