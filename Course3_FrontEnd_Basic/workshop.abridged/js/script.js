var bookDataFromLocalStorage = [];
var max = 0;
var Category;
var Name;
var Autor;
var BroughtDate;
var Publish;
var Search;
$(function(){

    loadBookData();
    var data = [
        {text:"資料庫",value:"image/database.jpg"},
        {text:"網際網路",value:"image/internet.jpg"},
        {text:"應用系統整合",value:"image/system.jpg"},
        {text:"家庭保健",value:"image/home.jpg"},
        {text:"語言",value:"image/language.jpg"},
        {text:"行銷",value:"image/marketing.jpg"},
        {text:"管理",value:"image/manage.jpg"}
    ]
    $("#book_category").kendoDropDownList({
        dataTextField: "text",
        dataValueField: "value",
        dataSource: data,
        index: 0,
        change: onChange
    });
    $("#bought_datepicker").kendoDatePicker();
    $("#book_grid").kendoGrid({
        dataSource: {
            data: bookDataFromLocalStorage,
            schema: {
                model: {
                    fields: {
                        BookId: {type:"int"},
                        BookName: { type: "string" },
                        BookCategory: { type: "string" },
                        BookAuthor: { type: "string" },
                        BookBoughtDate: { type: "string" },
                        BookPublisher: {type: "string"}
                    }
                }
            },
            pageSize: 20,

        },
        toolbar: kendo.template("<div class='book-grid-toolbar'><input class='book-grid-search' placeholder='我想要找......' type='text'></input></div>"),
        height: 550,
        sortable: true,
        pageable: {
            input: true,
            numeric: false
        },
        columns: [
            { field: "BookId", title: "書籍編號",width:"10%"},
            { field: "BookName", title: "書籍名稱", width: "50%" },
            { field: "BookCategory", title: "書籍種類", width: "10%" },
            { field: "BookPublisher", title: "出版社", width: "15%" },
            { field: "BookAuthor", title: "作者", width: "15%" },
            { field: "BookBoughtDate", title: "購買日期", width: "15%" },
            { command: { text: "刪除", click: deleteBook }, title: " ", width: "120px" }
        ]
       
    });
//-----------------------------------Judge Space or not------------
    validator = $("#window").kendoValidator().data("kendoValidator");
//------------------------------------------------------------------
    for(var i = 0 ; i < bookDataFromLocalStorage.length ; i++){
        if(bookDataFromLocalStorage[i].BookId > max)
            max = bookDataFromLocalStorage[i].BookId;
    }
//-----------------------------------Select Book------------
    $(".book-grid-search").keyup( function(e){
        Search = $(".book-grid-search").val();
        $("#book_grid").data("kendoGrid").dataSource.filter({
            logic: "or",
            filters: [{ 
                field: "BookName", 
                operator: "contains", 
                value: Search, 
            }]
        })
    })

//-----------------------------------Click Add Book------------
    $(document).ready(function() {
        var myWindow = $("#window"),
            undo = $("#Not_Add_Button");

        undo.click(function() {
            myWindow.data("kendoWindow").open();
            undo.fadeOut();
        });

        function onClose() {
            undo.fadeIn();
        }

        myWindow.kendoWindow({
            width: "700px",
            height: "600px",
            title: "新增書籍",
            visible: false,
            actions: [
                "Pin",
                "Minimize",
                "Maximize",
                "Close"
            ],
            close: onClose
        });//.data("kendoWindow").center().open();   //First Time Don't FadeIN()
    });
//-----------------------------------Add Book------------
    $("#Add_Button").click(function(){
//-----------------------------------Judge Space or not------------
        if(validator.validate()){
            max++;
            Category = $("#book_category").data("kendoDropDownList").text();
            Name = $("#book_name").val();
            Autor = $("#book_author").val();
            BroughtDate = kendo.toString(new Date($("#bought_datepicker").val()),"yyyy-MM-dd");
            Publish = $("#book_publish").val();
            // console.log(Category);
            // console.log(Name);
            // console.log(Autor);
            // console.log(BroughtDate);
            // console.log(max);
            // console.log(Publish);
            //---------------------------------------------Check value
            bookDataFromLocalStorage.push({
                "BookAuthor" : Autor,
                "BookBoughtDate" : BroughtDate,
                "BookCategory" : Category,
                "BookId" : max,
                "BookName" : Name,
                "BookPublisher" : Publish,
            })
            $("#window").data("kendoWindow").close();
            localStorage["bookData"] = JSON.stringify(bookDataFromLocalStorage);
            $("#book_grid").data('kendoGrid').dataSource.data(bookDataFromLocalStorage);
        }
//------------------------------------------------------------------
    })
})

function loadBookData(){
    bookDataFromLocalStorage = JSON.parse(localStorage.getItem("bookData"));
    if(bookDataFromLocalStorage == null){
        bookDataFromLocalStorage = bookData;
        localStorage.setItem("bookData",JSON.stringify(bookDataFromLocalStorage));
    }
}
//-----------------------------------Select Picture------------
function onChange(){
    $(".book-image").attr("src",$("#book_category").val())
}
//-----------------------------------Delete Book------------
function deleteBook(e){
    var id = this.dataItem($(e.currentTarget).closest("tr")).BookId
    for(var i = 0 ; i < bookDataFromLocalStorage.length ; i++){
        if(bookDataFromLocalStorage[i].BookId == id){
            bookDataFromLocalStorage.splice(i,1)
            break;
        }
    }
    localStorage["bookData"] = JSON.stringify(bookDataFromLocalStorage);
    $("#book_grid").data('kendoGrid').dataSource.data(bookDataFromLocalStorage);
}

