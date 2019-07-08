SELECT	A.Seq,
		A.BookClass,
		A.BookID,
		A.BookName,
		A.Cnt
FROM(
	SELECT	Seq = ROW_NUMBER() OVER (PARTITION BY bc.BOOK_CLASS_NAME ORDER BY  COUNT(blr.BOOK_ID)DESC),
			bc.BOOK_CLASS_NAME AS BookClass,
			blr.BOOK_ID AS BookID,
			bd.BOOK_NAME AS BookName,
			COUNT(blr.BOOK_ID) AS Cnt
		
	FROM  BOOK_DATA AS bd
	INNER JOIN BOOK_LEND_RECORD AS blr 
	ON blr.BOOK_ID = bd.BOOK_ID
	INNER JOIN BOOK_CLASS AS bc
	ON bd.BOOK_CLASS_ID = bc.BOOK_CLASS_ID

	GROUP BY blr.BOOK_ID , bc.BOOK_CLASS_NAME  ,bd.BOOK_NAME

)A
WHERE Seq <=3
ORDER BY BookClass,Cnt DESC,BookID