﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresProject_Gibson.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> webQueue = new Queue<string>();
        // GET: Queue
        public ActionResult QueueIndex()
        {
            return View();
        }

        /*generate a new value (New Entry # - maybe find out the number 
         * of items in the data structure and add 1 to it) and then insert it input 
         * into the data structure.*/
        public ActionResult AddOne()
        {
            webQueue.Enqueue("New Entry " + (webQueue.Count() + 1));

            ViewBag.Error = "<div class=\"w3-panel w3-green w3-display-container\">";
            ViewBag.Error += "<span onclick=\"this.parentElement.style.display='none'\"";
            ViewBag.Error += "class=\"w3-button w3-green w3-large w3-display-topright\">&times;</span>";
            ViewBag.Error += "<h3>Done!</h3>";
            ViewBag.Error += "<p>\"New Entry " + webQueue.Count() + "\" successfully added to the queue.</p></div>";

            return View("QueueIndex");
        }

        /*first clears the data structure and then generate 2,000 items in the data structure with the value of “New Entry” 
         * concatenated with the number. For example, New Entry 1, New Entry 2, New Entry 3. 
         * For the dictionary, the key will be the generated string ("New Entry 2") and the value will be the current number (2).*/
        public ActionResult AddHugeList()
        {
            webQueue.Clear();
            for (int i = 1; i <= 2000; i++)
            {
                webQueue.Enqueue("New Entry " + i);
            }

            ViewBag.Error = "<div class=\"w3-panel w3-green w3-display-container\">";
            ViewBag.Error += "<span onclick=\"this.parentElement.style.display='none'\"";
            ViewBag.Error += "class=\"w3-button w3-green w3-large w3-display-topright\">&times;</span>";
            ViewBag.Error += "<h3>Complete!</h3>";
            ViewBag.Error += "<p>Queue successfully replaced with 2000 new entries.</p></div>";

            return View("QueueIndex");
        }

        /*display the contents of the data structure. You must use the foreach loop when displaying 
         * the data. Handle any errors and inform the user. NOTE: You can send it back to the Index 
         * view or make another view*/
        public ActionResult Display()
        {
            if (webQueue.Count() > 0)
            {
                ViewBag.Queue = "<table class=\"w3-table-all\"><tr class=\"w3-deep-orange\"><th>Queue Value</th></tr>";
                foreach (string item in webQueue)
                {
                    ViewBag.Queue += "<tr><td>" + item + "</td></tr>";
                }
                ViewBag.Queue += "</table>";
            }
            else
            {
                ViewBag.Error = "<div class=\"w3-panel w3-blue w3-display-container\">";
                ViewBag.Error += "<span onclick=\"this.parentElement.style.display='none'\"";
                ViewBag.Error += "class=\"w3-button w3-blue w3-large w3-display-topright\">&times;</span>";
                ViewBag.Error += "<h3>Not much going on here...</h3>";
                ViewBag.Error += "<p>The Queue is empty.</p></div>";
            }

            return View("QueueIndex");
        }

        /*delete any item from the structure. 
         * Handle any errors and inform the user somewhere on the form if it cannot delete. 
         * HINT: Use the ViewBag*/
        public ActionResult Delete()
        {
            if (webQueue.Count() > 0)
            {
                string deleted = webQueue.Dequeue();
                ViewBag.Error = "<div class=\"w3-panel w3-green w3-display-container\">";
                ViewBag.Error += "<span onclick=\"this.parentElement.style.display='none'\"";
                ViewBag.Error += "class=\"w3-button w3-green w3-large w3-display-topright\">&times;</span>";
                ViewBag.Error += "<h3>Finished!</h3>";
                ViewBag.Error += "<p>\"" + deleted + "\" successfully deleted.</p></div>";
            }
            else
            {
                ViewBag.Error = "<div class=\"w3-panel w3-yellow w3-display-container\">";
                ViewBag.Error += "<span onclick=\"this.parentElement.style.display='none'\"";
                ViewBag.Error += "class=\"w3-button w3-yellow w3-large w3-display-topright\">&times;</span>";
                ViewBag.Error += "<h3>Error!</h3>";
                ViewBag.Error += "<p>Queue is already empty.</p></div>";
            }

            return View("QueueIndex");
        }

        /*wipe out the contents of the data structure*/
        public ActionResult Clear()
        {
            if (webQueue.Count() > 0)
            {
                webQueue.Clear();

                ViewBag.Error = "<div class=\"w3-panel w3-green w3-display-container\">";
                ViewBag.Error += "<span onclick=\"this.parentElement.style.display='none'\"";
                ViewBag.Error += "class=\"w3-button w3-green w3-large w3-display-topright\">&times;</span>";
                ViewBag.Error += "<h3>Success!</h3>";
                ViewBag.Error += "<p>Queue is now empty.</p></div>";
            }
            else
            {
                ViewBag.Error = "<div class=\"w3-panel w3-blue w3-display-container\">";
                ViewBag.Error += "<span onclick=\"this.parentElement.style.display='none'\"";
                ViewBag.Error += "class=\"w3-button w3-blue w3-large w3-display-topright\">&times;</span>";
                ViewBag.Error += "<h3>Wait...</h3>";
                ViewBag.Error += "<p>The queue is already empty.</p></div>";
            }

            return View("QueueIndex");
        }

        /*Search for any item in the data structure (hardcoded) and return if it was found or not 
         * found and how long it took to search. You can create a StopWatch object using code like 
         * so (just a simple example). Then display the information in the view. You can pass this 
         * result back to the view in the ViewBag and display it somewhere on the view*/

        /*public ActionResult EnterSearch()
        {
            
            ViewBag.Search = "<div class=\"w3-container w3-deep-orange\">";
            ViewBag.Search += "<h3> Enter Item to Search </h3>";
            ViewBag.Search += "</div>";

            ViewBag.Search += "<form class=\"w3-container\">";

            ViewBag.Search += "<p><label class=\"w3-text-dark-gray\"><b>New Entry #:</b></label>";
            ViewBag.Search += "<input class=\"w3-input w3-border w3-light-grey\" type=\"text\" value=\"Enter an entry number\"></p>";

            ViewBag.Search += "<p><button class=\"w3-btn w3-dark-gray\" formaction=\"@Url.Action(\"Search\", \"Queue\")\">Search</p>";
            ViewBag.Search += "</form>";

            return View("QueueIndex");
        }*/
        public ActionResult Search()
        {
            if (webQueue.Count > 0)
            {
                bool found = false;
                int entryNum;

                Random rand = new Random();
                entryNum = rand.Next(1, (webQueue.Count() * 2) + 1);

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                sw.Start();

                foreach (string item in webQueue)
                {
                    if (item == "New Entry " + entryNum)
                    {
                        found = true;
                        break;
                    }
                    else
                    {
                        found = false;
                    }
                }

                sw.Stop();

                TimeSpan ts = sw.Elapsed;

                if (found)
                {
                    ViewBag.Error = "<div class=\"w3-panel w3-green w3-display-container\">";
                    ViewBag.Error += "<span onclick=\"this.parentElement.style.display='none'\"";
                    ViewBag.Error += "class=\"w3-button w3-green w3-large w3-display-topright\">&times;</span>";
                    ViewBag.Error += "<h3>Found it!</h3>";
                    ViewBag.Error += "<p> Searched for \"New Entry " + entryNum + "\", and we found it! Elapsed time: " + ts + ".</p></div>";
                }
                else
                {
                    ViewBag.Error = "<div class=\"w3-panel w3-yellow w3-display-container\">";
                    ViewBag.Error += "<span onclick=\"this.parentElement.style.display='none'\"";
                    ViewBag.Error += "class=\"w3-button w3-yellow w3-large w3-display-topright\">&times;</span>";
                    ViewBag.Error += "<h3>Sorry!</h3>";
                    ViewBag.Error += "<p> Searched for \"New Entry " + entryNum + "\", which was not found. Elapsed time: " + ts + ".</p></div>";
                }
            }
            else
            {
                ViewBag.Error = "<div class=\"w3-panel w3-yellow w3-display-container\">";
                ViewBag.Error += "<span onclick=\"this.parentElement.style.display='none'\"";
                ViewBag.Error += "class=\"w3-button w3-yellow w3-large w3-display-topright\">&times;</span>";
                ViewBag.Error += "<h3>Oops!</h3>";
                ViewBag.Error += "<p>Can't search an empty queue!</p></div>";
            }
            return View("QueueIndex");
        }
    }
}