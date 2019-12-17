   function showAlterar(){
            var y =  document.getElementById("pord");
            if (y.style.display === "none") {
                y.style.display = "block";   
                document.getElementById("contorno-style").style.height = "616px ";
                document.getElementById("contorno-style").style.width = "389px";
                document.getElementById("po-ord-div-3-flex-perf").style.height = "597px";
                document.getElementById("po-ord-div-3-flex-perf").style.width = "369px";
                document.getElementById("po-ord-div-2-perf").style.height = "47em";
                document.getElementById("po-ord-div-4-flex-btn-perf").style.display = "none";
            }else{
                y.style.display = "none";
                document.getElementById("contorno-style").style.height = "359px ";
                document.getElementById("contorno-style").style.width = "389px";
                document.getElementById("po-ord-div-3-flex-perf").style.height = "339px";
                document.getElementById("po-ord-div-3-flex-perf").style.width = "369px";   
                document.getElementById("po-ord-div-4-flex-btn-perf").style.display = "";
            }
        }