# OrderRulesEngine
Rules an order goes through on checkout.

## Projects
* OrderRulesEngine: Actual solution
* OrderRulesEngine.Runner: For test purposes (running the rules)
* OrderRulesEngine.Test: Unit tests

## Remarks
* I chose to not combine rules that belong together domain-wise (1+2, 3+4+5)
	- This would reduce code footprint, but this way shows some how generic this solution is
* The ShouldProcess/Process logic can be done in several different ways. Process could check a boolean, Process could call the check itself, etc.
* Base project could be split in to Logic, DataAccess and Common/Core