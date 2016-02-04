package SkipList;

interface SkippableList<T extends Comparable<? super T>> {
	int LEVELS = 5;

	boolean delete(T target);
	void print();
	void insert(T key);
	SkipNode<T> search(T key);
}
