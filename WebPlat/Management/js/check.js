function check(myform){
	if (myform.userName.value==""){
		alert('�������û���!');myform.username.focus();return;
	}
	if (myform.pwd.value==""){
		alert('��������������!');myform.pwd.focus();return;
	}	
	if (myform.pwd1.value==""){
		alert('��������������!');myform.pwd1.focus();return;
	}
	if (myform.pwd.value!=myform.pwd1.value){
		alert('���ٴ�������������!');myform.pwd.focus();return;
	}		
	if (myform.email.value==""){
		alert('����������email!');myform.email.focus();return;
	}
	var i=myform.email.value.indexOf("@");
	var j=myform.email.value.indexOf(".");
	if((i<0)||(i-j>0)||(j<0)){
		alert('����ȷ��������email!');myform.email.value="";myform.email.focus();return;
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
		alert('���������!');myform.title.focus();return;
	}
	if(document.getElementById("content").value==""){
		alert('����������');myform.content.focus();return;
	}
	if(document.getElementById("add_time").value==""){
		alert('��ѡ������');myform.add_time.focus();return;
	}
	myform.submit();
}


function checkM(myform){
	if(myform.manager.value==""){
		alert('�������½��');myform.manager.focus();return;
	}
	if(myform.PWD.value==""){
		alert("����������");myform.PWD.focus();return;
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
		alert('��ѡ����Ҫɾ����ѡ��');
		return false;
	}else{
			if(confirm( '��ȷ��Ҫɾ����ѡ������ ')==true){
				formname.submit();
		}
	}
}