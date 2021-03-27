using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redis.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Controllers
{
    public class RedisController : Controller
    {
        RedisService _redisService;

        public RedisController(RedisService redisService)
        {
            _redisService = redisService;
        }
        // Redis String
        public IActionResult Index()
        {
            IDatabase database = _redisService.GetDb(1);
            //SET
            database.StringSet("name", "salih");
            //GET
            string value_get = database.StringGet("name");
            Console.WriteLine($"Get : {value_get}");
            //APPEND
            database.StringAppend("name", " kral");
            string value_append = database.StringGet("name");
            Console.WriteLine($"Append : {value_append}");
            //INCR
            database.StringSet("count", 1);
            long value_count = database.StringIncrement("count");
            Console.WriteLine($"Incr : {value_count}");
            //GETRANGE
            string value_getrange = database.StringGetRange("name", 1, 2);
            Console.WriteLine($"Getrange : {value_getrange}");

            return View();
        }
        // Redis List
        public IActionResult Index2()
        {
            IDatabase database = _redisService.GetDb(1);
            //LPUSH
            database.ListLeftPush("krallar", "kral1");
            database.ListLeftPush("krallar", "kral2");
            database.ListLeftPush("krallar", "kral3");
            //RPUSH
            database.ListRightPush("krallar", "kral4");
            database.ListRightPush("krallar", "kral5");
            database.ListRightPush("krallar", "kral6");
            //LRANGE
            RedisValue[] values = database.ListRange("krallar", 0, -1);
            int count = 1;
            values.ToList().ForEach(o => Console.WriteLine($"kral {count++} - {o}"));
            //LPOP
            string left_pop = database.ListLeftPop("krallar");
            Console.WriteLine($"LPOP : {left_pop}");
            //RPOP
            string right_pop = database.ListRightPop("krallar");
            Console.WriteLine($"RPOP : {right_pop}");
            //LINDEX
            string index_value = database.ListGetByIndex("krallar", 2);
            Console.WriteLine($"LINDEX : {index_value}");
            return View();
        }
        //Redis Set
        public IActionResult Index3()
        {
            IDatabase database = _redisService.GetDb(1);
            //SADD
            database.SetAdd("color", "blue");
            database.SetAdd("color", "red");
            database.SetAdd("color", "white");
            database.SetAdd("color", "black");
            //SETMEMBERS
            RedisValue[] values = database.SetMembers("color");
            values.ToList().ForEach(c => Console.WriteLine(c));
            //SREM
            database.SetRemove("color", "white");
            Console.WriteLine("****");
            values = database.SetMembers("color");
            values.ToList().ForEach(c => Console.WriteLine(c));
            return View();
        }
        // Redis Sorted Set
        public IActionResult Index4()
        {
            IDatabase database = _redisService.GetDb(1);
            //ZADD
            database.SortedSetAdd("esya", "kalem", 5);
            database.SortedSetAdd("esya", "silgi", 10);
            database.SortedSetAdd("esya", "defter", 15);
            database.SortedSetAdd("esya", "kağıt", 2);
            //ZRANGE
            RedisValue[] values = database.SortedSetRangeByRank("esya", 0, -1);
            values.ToList().ForEach(e => Console.WriteLine(e));
            //ZRANGE - WITHSCORES
            SortedSetEntry[] values2 = database.SortedSetRangeByRankWithScores("esya", 0, -1);
            Console.WriteLine("****");
            values2.ToList().ForEach(e => Console.WriteLine(e));
            //ZREM
            database.SortedSetRemove("esya", "kalem");
            Console.WriteLine("****");
            values = database.SortedSetRangeByRank("esya", 0, -1);
            values.ToList().ForEach(e => Console.WriteLine(e));
            return View();
        }
        // Redis Hash
        public IActionResult Index5()
        {
            IDatabase database = _redisService.GetDb(1);
            //HMSET
            database.HashSet("sozluk", "pen", "kalem");
            database.HashSet("sozluk", "mouse", "fare");
            database.HashSet("sozluk", "dog", "köpek");
            database.HashSet("sozluk", "cat", "kedi");
            //HMGET
            string value_cat = database.HashGet("sozluk", "cat");
            Console.WriteLine(value_cat);
            //HDEL
            database.HashDelete("sozluk", "mouse");
            //HGETALL
            HashEntry[] values = database.HashGetAll("sozluk");
            values.ToList().ForEach(h => Console.WriteLine(h));
            return View();
        }
    }
}
