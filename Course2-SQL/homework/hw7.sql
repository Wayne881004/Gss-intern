SELECT	blr.BOOK_ID AS '�ѥ�ID',
		FORMAT(bd.BOOK_BOUGHT_DATE,'yyyy'+'/'+'MM' + '/' + 'dd' )AS '�ʮѤ��',
		FORMAT(blr.LEND_DATE,'yyyy'+'/'+'MM' + '/' + 'dd' )AS '�ɮѤ��',
		bd.BOOK_CLASS_ID  + '-' + bclass.BOOK_CLASS_NAME AS '���y���O',
		blr.KEEPER_ID + '-' + mm.USER_CNAME AS  '�ɾ\�H',
		bcode.CODE_ID + '-' + bcode.CODE_NAME AS '���A',
		CONVERT(nvarchar, bd.BOOK_AMOUNT)  + '��' AS '�ʮѪ��B'
FROM BOOK_LEND_RECORD AS blr
INNER JOIN BOOK_DATA AS bd
ON blr.BOOK_ID = bd.BOOK_ID
INNER JOIN BOOK_CLASS AS bclass
ON bd.BOOK_CLASS_ID = bclass.BOOK_CLASS_ID
INNER JOIN MEMBER_M mm
ON blr.KEEPER_ID = mm.[USER_ID]
INNER JOIN BOOK_CODE bcode
ON bd.BOOK_STATUS = bcode.CODE_ID

WHERE mm.USER_CNAME = '���|' 
GROUP BY	blr.BOOK_ID ,
			bd.BOOK_BOUGHT_DATE ,
			blr.LEND_DATE , 
			bd.BOOK_CLASS_ID , bclass.BOOK_CLASS_NAME,
			blr.KEEPER_ID , mm.USER_CNAME,
			bcode.CODE_ID , bcode.CODE_NAME , 
			bd.BOOK_AMOUNT

ORDER BY bd.BOOK_AMOUNT DESC