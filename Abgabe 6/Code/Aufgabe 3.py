#!/usr/bin/env python

import random
from math import floor


def countsort(lst, k):
	counter = [0] * (k + 1)

	for i in lst:
		counter[i] += 1
 
	ndx = 0;
	for i in range(len(counter)):
		while counter[i] > 0:
			lst[ndx] = i
			ndx += 1
			counter[i] -= 1

	return lst

def heapsort(lst):
	def buildMaxHeap(lst, start, end):
		root = start

		while True:
			child = root * 2 + 1

			if child > end:
				break

			if child + 1 <= end and lst[child] < lst[child + 1]:
				child += 1

			if lst[root] < lst[child]:
				lst[root], lst[child] = lst[child], lst[root]
				root = child
			else:
				break
	  
	# inline heapify
	for start in range((len(lst)-2)/2, -1, -1):
		buildMaxHeap(lst, start, len(lst)-1)
 
	for end in range(len(lst)-1, 0, -1):
		lst[end], lst[0] = lst[0], lst[end]
		buildMaxHeap(lst, 0, end - 1)

	return lst

def mapsort(lst, c):
	newn = int(len(lst) * c)
	bucket = [-1] * newn
	minVal, maxVal = min(lst), max(lst)

	dist = (maxVal - minVal) / float(newn - 1)

	for i in range(len(lst)):
		t = int(floor((lst[i]-minVal) / dist))
		insert = lst[i]
		left = 0

		if bucket[t] != -1 and insert <= bucket[t]:
			left = 1;

		while bucket[t] != -1:
			if left == 1:
				if insert > bucket[t]:
					insert, bucket[t] = bucket[t], insert
				if t > 0:
					t -= 1
				else:
					left = 0
			else:
				if insert <= bucket[t]:
					insert, bucket[t] = bucket[t], insert
				if t < newn - 1:
					t += 1
				else:
					left = 1

		bucket[t] = insert;

	j = 0
	for i in range(newn):
		if bucket[i] != -1:
			lst[j] = bucket[i]
			j += 1

	return lst

def generate_list():
	return [random.randint(1000, 10000) for r in range(random.randint(10, 1000))]


testCSort = lambda: countsort(generate_list(), 10000)
testHSort = lambda: heapsort(generate_list())
testMSort = lambda: mapsort(generate_list(), 1.5)


if __name__ == '__main__':
	import timeit
	print(timeit.timeit("testCSort()", setup="from __main__ import testCSort", number=10))
	print(timeit.timeit("testHSort()", setup="from __main__ import testHSort", number=10))
	print(timeit.timeit("testMSort()", setup="from __main__ import testMSort", number=10))
