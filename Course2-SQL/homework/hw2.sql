SELECT	TOP 5 	
		bd.BOOK_ID AS BookID,
		bd.BOOK_NAME AS BookName,
	    COUNT(bd.BOOK_ID) AS QTY 
	
FROM BOOK_DATA AS bd 
INNER JOIN BOOK_LEND_RECORD AS blr
ON bd.BOOK_ID = blr.BOOK_ID

GROUP BY bd.BOOK_ID , bd.BOOK_NAME 
ORDER BY QTY DESC