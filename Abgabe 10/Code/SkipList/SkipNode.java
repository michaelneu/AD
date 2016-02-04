package SkipList;

class SkipNode<N extends Comparable<? super N>> {

	N key;
	@SuppressWarnings("unchecked")
	SkipNode<N>[] next = (SkipNode<N>[]) new SkipNode[SkippableList.LEVELS];

	SkipNode(N key) {
		this.key = key;
	}

	void refreshAfterDelete(int level) {
		SkipNode<N> current = this.getNext(level);
		while (current != null && current.getNext(level) != null) {
			if (current.getNext(level).key == null) {
				SkipNode<N> successor = current.getNext(level).getNext(level);
				current.setNext(successor, level);
				return;
			}

			current = current.getNext(level);
		}
	}

	void setNext(SkipNode<N> next, int level) {
		this.next[level] = next;
	}

	SkipNode<N> getNext(int level) {
		return this.next[level];
	}

	SkipNode<N> search(N key, int level, boolean print) {
		if (print) {
			System.out.print("Searching for: " + key + " at ");
			print(level);
		}

		SkipNode<N> result = null;
		SkipNode<N> current = this.getNext(level);
		while (current != null && current.key.compareTo(key) < 1) {
			if (current.key.equals(key)) {
				result = current;
				break;
			}

			current = current.getNext(level);
		}

		return result;
	}

	void insert(SkipNode<N> SkipNode, int level) {
		SkipNode<N> current = this.getNext(level);
		if (current == null) {
			this.setNext(SkipNode, level);
			return;
		}

		if (SkipNode.key.compareTo(current.key) < 1) {
			this.setNext(SkipNode, level);
			SkipNode.setNext(current, level);
			return;
		}

		while (current.getNext(level) != null && current.key.compareTo(SkipNode.key) < 1 && 
				current.getNext(level).key.compareTo(SkipNode.key) < 1) {

			current = current.getNext(level);
		}

		SkipNode<N> successor = current.getNext(level);
		current.setNext(SkipNode, level);
		SkipNode.setNext(successor, level);
	}

	void print(int level) {
		System.out.print("level " + level + ": [");
		int length = 0;
		SkipNode<N> current = this.getNext(level);
		while (current != null) {
			length++;
			System.out.print(current.key.toString() + " ");
			current = current.getNext(level);
		}

		System.out.println("], length: " + length);
	}

}
