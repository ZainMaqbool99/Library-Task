
$(document).ready(() => {
    var defaultItem = "<option value = '0'>Select</option>"
    $('#SubCategoryId').html(defaultItem);
});

const get_sub_cats=async (catid)=>{
    let response =  await fetch('/Home/getSubCategories?categoryId='+catid, {
        method: "GET",
    })

    if(response.ok)
    {
        let data = await response.json();
        return data;
    }
}

const get_book_details = async (subcatId) => {
    let response = await fetch("/Home/GetBookDetail?subCatId="+subcatId, {
        method: "GET"
    })
    if(response.ok)
    {
        let data = await response.json();
        console.log(data);
        return data;
    }
}

$('#btnView').click(async () => {
    let val= document.getElementById('SubCategoryId').value;
    let data = await get_book_details(val);

    let html =''

    $('#tblView').empty();
    html += "<tr class='tr'>"
    html += "<th class='th'>BookId</th>"
    html += "<th class='th'>BookName</th>"
    html += "<th class='th'>Author</th>"
    html += "</tr>"
    $.each(data,(i,item)=>{
        html += "<tr class='tr'>"
        html += "<td class='td'>"+item.bookId+"</td>"
        html += "<td class='td'>"+item.bookName+"</td>"
        html += "<td class='td'>Germany</td>"
        html += "</tr>"
    })
    $('#tblView').html(html)
})

$('#CategoryId').change(async()=>{
    SetTableEmpty();
    let val= document.getElementById('CategoryId').value;
    let html =''
    let data= await get_sub_cats(val);
    $('#SubCategoryId').empty();
    $.each(data,(i,item)=>{
    html= html+"<option value='"+item.subCategoryId+"'>"+item.subCategoryName+"</option>"
    })
    $('#SubCategoryId').html(html)
})

$('#SubCategoryId').change(()=>{
    SetTableEmpty();
});

const SetTableEmpty = () =>  {
    let html = '';
    $('#tblView').empty();
    html += "<tr class='tr'>"
    html += "<th class='th'>BookId</th>"
    html += "<th class='th'>BookName</th>"
    html += "<th class='th'>Author</th>"
    html += "</tr>"
    $('#tblView').html(html);
}





