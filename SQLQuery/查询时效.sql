select * from DD_CreateTime;

SELECT
	[SX_BMNum] AS '客户编码',
	[DD_RQ] AS '订单日期',
	[DD_QR_Time] AS '订单确认时间',
	[DD_SD_Time] AS '送达时间',
	(
	CASE			
			WHEN SUBSTRING ( CONVERT ( VARCHAR, DD_QR_Time, 120 ), 12, 8 ) BETWEEN '08:00:00' 
			AND '16:30:00' THEN
				'当天' 
				WHEN SUBSTRING ( CONVERT ( VARCHAR, DD_QR_Time, 120 ), 12, 8 ) BETWEEN '16:30:01' 
				AND '23:59:59' THEN
					'次日' ELSE '凌晨' 
				END 
				) AS 节点区分 
			FROM
				DD_CreateTime 
			WHERE
				DD_SD_Time IS NOT NULL 
				and
				 convert(varchar(10),[DD_RQ],120) between '2019-06-01' and '2019-06-30' 
		ORDER BY
	节点区分 DESC


