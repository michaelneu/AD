package SkipList;
import java.util.Random;

public class SkipList<K extends Comparable<? super K>> implements SkippableList<K> {

	public static void main(String[] args) {
		SkipList<Integer> sl = new SkipList<>();
		int[] keys = {4,2,7,0,9,1,3,7,3,4,5,6,0,2,8};
		for (int i : keys) {
			sl.insert(i);
		}

		sl.print();
		sl.search(4);

		sl.delete(9);
		sl.print();

		sl.insert(69);
		sl.print();
		sl.search(69);
	}

	private final SkipNode<K> head = new SkipNode<>(null);
	private final Random rand = new Random();

	@Override
	public void insert(K key) {
		SkipNode<K> SkipNode = new SkipNode<>(key);
		for (int i = 0; i < LEVELS; i++) {
			if (rand.nextInt((int) Math.pow(2, i)) == 0) { //insert with prob = 1/(2^i)
				insert(SkipNode, i);
			}
		}
	}

	@Override
	public boolean delete(K key) {
		SkipNode<K> victim = search(key, false);
		if (victim == null) return false;
		victim.key = null;

		for (int i = 0; i < LEVELS; i++) {
			head.refreshAfterDelete(i);
		}
		return true;
	}

	@Override
	public SkipNode<K> search(K key) {
		return search(key, true);
	}

	@Override
	public void print() {
		for (int i = 0; i < LEVELS; i++) {
			head.print(i);
		}

		System.out.println();
	}

	private void insert(SkipNode<K> SkipNode, int level) {
		head.insert(SkipNode, level);
	}

	private SkipNode<K> search(K key, boolean print) {
		SkipNode<K> result = null;
		for (int i = LEVELS-1; i >= 0; i--) {
			if ((result = head.search(key, i, print)) != null) {
				if (print) {
					System.out.println("Found " + key.toString() + " at level " + i + ", so stoppped" );
					System.out.println();
				}

				break;
			}
		}

		return result;
	}

}