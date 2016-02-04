#!/bin/env python2

def h_hat(s): 
	return s

class Hashtable:
	def __init__(self, size): 
		if size < 1: 
			raise Exception("Only positive sizes allowed")

		self.table = [None] * size
		self.size = size

	def is_free(self, position): 
		if abs(position) < self.size: 
			return self.table[position] == None
		else: 
			return False

	def hash(self, value): 
		position = value % self.size

		if self.is_free(position): 
			return position
		else:
			return -1

	def insert(self, value): 
		position, collisions = self.hash(value)

		if position != -1: 
			self.table[position] = value

		return collisions

class LinearHashtable(Hashtable): 
	def hash(self, value): 
		for i in range(self.size): 
			position = (h_hat(value) + i) % self.size

			if self.is_free(position): 
				return (position, i)

		return (-1, self.size)

class QuadraticHashtable(Hashtable): 
	def hash(self, value): 
		c_1 = 1
		c_2 = 3

		for i in range(self.size): 
			position = (h_hat(value) + c_1 * i + c_2 * i**2) % self.size

			if self.is_free(position): 
				return (position, i)

		return (-1, self.size)

class DoubleHashtable(Hashtable): 
	def h_1(self, value): 
		return value

	def h_2(self, value): 
		return 1 + (value % (self.size - 1))

	def hash(self, value): 
		for i in range(self.size): 
			position = (self.h_1(value) + i * self.h_2(value)) % self.size

			if self.is_free(position): 
				return (position, i)

		return (-1, self.size)