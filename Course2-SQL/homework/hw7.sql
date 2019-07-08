SELECT	blr.BOOK_ID AS '書本ID',
		FORMAT(bd.BOOK_BOUGHT_DATE,'yyyy'+'/'+'MM' + '/' + 'dd' )AS '購書日期',
		FORMAT(blr.LEND_DATE,'yyyy'+'/'+'MM' + '/' + 'dd' )AS '借書日期',
		bd.BOOK_CLASS_ID  + '-' + bclass.BOOK_CLASS_NAME AS '書籍類別',
		blr.KEEPER_ID + '-' + mm.USER_CNAME AS  '借閱人',
		bcode.CODE_ID + '-' + bcode.CODE_NAME AS '狀態',
		CONVERT(nvarchar, bd.BOOK_AMOUNT)  + '元' AS '購書金額'
FROM BOOK_LEND_RECORD AS blr
INNER JOIN BOOK_DATA AS bd
ON blr.BOOK_ID = bd.BOOK_ID
INNER JOIN BOOK_CLASS AS bclass
ON bd.BOOK_CLASS_ID = bclass.BOOK_CLASS_ID
INNER JOIN MEMBER_M mm
ON blr.KEEPER_ID = mm.[USER_ID]
INNER JOIN BOOK_CODE bcode
ON bd.BOOK_STATUS = bcode.CODE_ID

WHERE mm.USER_CNAME = '李四' 
GROUP BY	blr.BOOK_ID ,
			bd.BOOK_BOUGHT_DATE ,
			blr.LEND_DATE , 
			bd.BOOK_CLASS_ID , bclass.BOOK_CLASS_NAME,
			blr.KEEPER_ID , mm.USER_CNAME,
			bcode.CODE_ID , bcode.CODE_NAME , 
			bd.BOOK_AMOUNT

ORDER BY bd.BOOK_AMOUNT DESC