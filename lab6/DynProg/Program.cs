using DynProg;

// TASK 1
/* 
 * By the beginning of the analyzed period, new equipment was installed at the enterprise.
 * Determine the optimal equipment replacement cycle
*/
int time = 8, replacementCost = 11;
ISolvable lab = new Task_1(time, replacementCost, new int[] { 11, 10, 9, 8, 7, 5, 3, 1, 0});
lab.Solve();

// TASK 2
/*
 * The firm's board of directors is considering proposals to increase production capacity 
to increase the output of homogeneous products at the four plants owned by the firm.
 * To modernize the enterprises, the Board of Directors invests funds in the amount of
RUR 250 mln. with the discretionary amount of RUR 50 mln. The increase in output
depends on the allocated amount, its values are presented by enterprises and
are contained in the table
*/

var arr = new int[6, 4] 
{
    { 0,  0,  0,  0  },
    { 15, 12, 17, 13 },
    { 32, 30, 33, 31 },
    { 39, 38, 40, 37 },
    { 46, 45, 47, 44 },
    { 52, 54, 60, 63 } 
};
int fabricNum = 4, money = 250, discreteness = 50;
lab = new Task_2(arr, fabricNum, money, discreteness);
lab.Solve();
