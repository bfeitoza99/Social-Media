import { useInfiniteQuery } from "@tanstack/react-query";
import { fetchPosts } from "@/services/post-service";
import { useFilterPostStore } from "@/store/useFilterPostStore";

export function useInfinitePosts() {
  const { orderBy, keyword } = useFilterPostStore();

  return useInfiniteQuery({
    queryKey: ["posts" ,orderBy, keyword],
    queryFn: ({ pageParam = 1 }) => fetchPosts(orderBy, keyword, pageParam),
    initialPageParam: 1, 
    getNextPageParam: (lastPage) => lastPage.nextPage ?? undefined, 
  });
}
