function check(myform){
	if (myform.userName.value==""){
		alert('请输入用户名!');myform.username.focus();return;
	}
	if (myform.pwd.value==""){
		alert('请输入您的密码!');myform.pwd.focus();return;
	}	
	if (myform.pwd1.value==""){
		alert('请输入您的密码!');myform.pwd1.focus();return;
	}
	if (myform.pwd.value!=myform.pwd1.value){
		alert('请再次输入您的密码!');myform.pwd.focus();return;
	}		
	if (myform.email.value==""){
		alert('请输入您的email!');myform.email.focus();return;
	}
	var i=myform.email.value.indexOf("@");
	var j=myform.email.value.indexOf(".");
	if((i<0)||(i-j>0)||(j<0)){
		alert('请正确输入您的email!');myform.email.value="";myform.email.focus();return;
	}		
}



function CheckAll(elementsA,elementsB){
	for(i=0;i<elementsA.length;i++){
		elementsA[i].checked = true;
	}
	if(elementsB.checked ==false){
		for(j=0;j<elementsA.length;j++){
			elementsA[j].checked = false;
		}
	}
}


	
function checkweb(myform){
	if(document.getElementById("title").value==""){
		alert('请输入标题!');myform.title.focus();return;
	}
	if(document.getElementById("content").value==""){
		alert('请输入内容');myform.content.focus();return;
	}
	if(document.getElementById("add_time").value==""){
		alert('请选择日期');myform.add_time.focus();return;
	}
	myform.submit();
}


function checkM(myform){
	if(myform.manager.value==""){
		alert('请输入登陆名');myform.manager.focus();return;
	}
	if(myform.PWD.value==""){
		alert("请输入密码");myform.PWD.focus();return;
	}
	myform.submit();
}

function checkdel(delid,formname){
	var flag = false;
	for(i=0;i<delid.length;i++){
		if(delid[i].checked){
			flag = true;
			break;
		}
	}
	if(!flag){
		alert('请选择您要删除的选项');
		return false;
	}else{
			if(confirm( '您确定要删除所选内容吗？ ')==true){
				formname.submit();
		}
	}
}