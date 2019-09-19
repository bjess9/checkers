-- --------------------------------------------------------------------- SAMPLE DATA ----------------------------------------------------------------------------------------

DELETE from piecelocation;
DELETE from game;
DELETE from playerdetail;

-- CHANGES MADE TO DATABASE DESIGN
	-- Removed the "inPlay" column, a piece is removed from the db if it leaves play instead

-- Sample players | One Admin | Three Online/Playing
INSERT INTO 	playerdetail 	(playerName, 	playerPassword, 				playerStatus,	rating,		admin)
VALUES 							('bob123', 		unhex(sha2('password1', 256)), 	'Offline', 		10,			'N'),
								('admin', 		unhex(Sha2('1', 256)), 			'Offline', 		10,			'Y'),
                                ('jess', 		unhex(sha2('1', 256)), 			'Offline', 		176,		'N'),
                                ('tim', 		unhex(sha2('1', 256)), 			'Online', 		176,		'N'),
                                ('jemma', 		unhex(sha2('1', 256)), 			'Online', 		176,		'N'),
								('corrina', 	unhex(sha2('1', 256)), 			'Online', 		154,		'N');
                           
-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


-- Running && Waiting game example
 -- INSERT INTO 	game 			(timeElapsed, 		timeStarted, 	currentTurn,	playerName1, 	playerName2)
 -- VALUES 							('00:10:45', 		now(), 			1, 				'sam123',		'tracey123'),
-- 									('00:01:32', 		now(), 			0, 				'karla123', 	null);


-- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


-- Running game Piece Locations
/*
 INSERT INTO 	piecelocation	(x, 	y, 		colour,		gameID)
 VALUES 						(3, 	5, 		0, 			1),
								(6, 	4, 		0, 			1),
                                (1, 	5, 		0, 			1),
                                (6, 	2, 		1, 			1),
                                (5, 	5, 		1, 			1);

-- Waiting game Piece Locations
INSERT INTO 	piecelocation	(x, 	y, 		colour,		gameID)
 VALUES 						(1, 	1, 		0, 			2),
								(3, 	1, 		0, 			2),
                                (5, 	1, 		0, 			2),
                                (7, 	1, 		0, 			2),
                                (2, 	2, 		0, 			2),
                                (4, 	2, 		0, 			2),
								(6, 	2, 		0, 			2),
                                (8, 	2, 		0, 			2),
                                (1, 	3, 		0, 			2),
                                (3, 	3, 		0, 			2),
                                (5, 	3, 		0, 			2),
								(7, 	3, 		0, 			2),
                                (2, 	6, 		1, 			2),
                                (4, 	6, 		1, 			2),
                                (6, 	6, 		1, 			2),
                                (8, 	6, 		1, 			2),
								(1, 	7, 		1, 			2),
                                (3, 	7, 		1, 			2),
                                (5, 	7, 		1, 			2),
                                (7, 	7, 		1, 			2),
                                (2, 	8, 		1, 			2),
								(4, 	8, 		1, 			2),
                                (6, 	8, 		1, 			2),
                                (8, 	8, 		1, 			2);
                                */
                                