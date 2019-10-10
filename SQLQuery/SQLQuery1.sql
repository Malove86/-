
SELECT
	[SX_BMNum] AS '��Ӫ��',
	[KF_Num] AS '�ͻ�����',
	[DD_RQ] AS '��������',	
	[DD_QR_Time] AS '����ȷ��ʱ��',
	[DD_SD_Time] AS '�ʹ�ʱ��',
	(
	CASE			
			WHEN SUBSTRING ( CONVERT ( VARCHAR, DD_QR_Time, 120 ), 12, 8 ) BETWEEN '08:00:00' 
			AND '16:30:00' THEN
				'����' 
				WHEN SUBSTRING ( CONVERT ( VARCHAR, DD_QR_Time, 120 ), 12, 8 ) BETWEEN '16:30:01' 
				AND '23:59:59' THEN
					'����' ELSE '�賿' 
				END 
				) AS �ڵ����� 
			FROM
				DD_CreateTime 
			WHERE
				DD_SD_Time IS NOT NULL 
				and
				 convert(varchar(10),[DD_RQ],120) between '2019-06-01' and '2019-08-31' 
				and SX_BMNum='14R'
		ORDER BY
	 [DD_RQ] ASC



