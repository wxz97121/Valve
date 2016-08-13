﻿using UnityEngine;
using System.Collections;

public class SpecialDialogue : MonoBehaviour
{
    public string[] Ask = { "嘿，小伙子，快给我拿点儿吃的。|让我出来排这么长时间的队，<color=#ff0000>你们军队可真能折腾人。</color>", "什么，不给？我没听错吧？|<color=#ff0000>这些补给品你打算独吞吗？快给我！</color>", "喂，有么有搞错啊，就只有这么点儿东西？<color=#ff0000>你是在打发我吗？再多给我一份儿！</color>", "哼，算你识相！", "如果我有枪，现在就会打死你！", "<b>出身贵族的本小姐</b>，也要和平民一起排队，真是灾难。|快点儿给我补给让我回家！", "难道想用平民的量打发本小姐？", "终于可以回家了，居然让<b>我这样的贵族</b>也亲自来排队，这该死的战争。", "<b>本小姐</b>记住你了！你会受到惩罚的！", "尊敬的长官，您好……我是一名<b>穆斯林</b>，请问，可以给我一份清真的食物吗？", "哦太好了，这很清真！愿真主阿拉保佑您！", "哦，愿真主保佑我度过战争……", "嘿，菜鸟。你去过前线吗！|如果你去过的话，一定听说我<b>穆勒将军</b>的大名吧！|快多给我几份儿补给。", "只有这些？你的教官没教过你怎么服务将军吗！|如果你去过前线上我的军队，你一定会被惩罚！|再来一包。", "愣着干嘛，继续给我多拿点儿啊。", "我看你是不想混了！你这种懦夫也只能在这里发发物资，一辈子去不了前线！<color=#ff0000>改天收拾你！</color>", "这还像话。替我问你们连长好，不过他听到我的大名八成会吓晕过去。哈哈哈哈哈哈！", "刚才我看到<b>穆勒</b>那个老混蛋了，我曾经跟随难民到过他的战区。|这人还是恶性不改，就该饿死他…… 哦，请给我今天的补给。", "这可不够我家里吃的，再来一包。", "你以为我和<b>穆勒</b>那种老混蛋是一种人吗？|难道你要让我们老实人受难？|<color=#ff0000>却把东西都留给那些军队下来的流氓？</color>", "哎这战争……无论哪个国家的军队，都是人民的敌人！", "但愿这些可以帮我度过这一段时间。", "刚才我看到<b>穆勒</b>那个老混蛋了，我曾经跟随难民到过他的战区……|我可看见你给他多少了，我也要一样多的量。", "这可比<b>穆勒</b>拿走的少！", "你指望可以扣减我的食物挪去给<b>穆勒</b>吗！<color=#ff0000>休想！</color>", "哎这战争……无论哪个国家的军队，都是人民的敌人！", "但愿这些可以帮我度过这一段时间。", "长官，<b>我的儿子叫戈麦斯</b>，是在前线的军人。|请问，您认识我的儿子吗，他已经很久没给我回信了|……哦，我也是来领补给的。", "…………如果您认识<b>我的儿子</b>，请一定告诉我他的消息！", "哦，你们这么对待一个老太婆……如果<b>我的儿子</b>在，我一定不会这么受苦的。", "刚才我看见了<b>汉娜老太婆</b>，她可真可怜，天天等他儿子的书信。|说是以前和穆勒在一个部队的|……哦，我也需要补给。", "愿真主阿拉保佑<b>汉娜老太婆</b>和他的儿子，也愿真主阿拉保佑您。", "战争就是地狱……", "嘿，这鬼天气真是太冷了。|听说战线就要压过来了，这可真是麻烦啊，我可不想去当傻瓜士兵……|哦长官，我当然不是说您，请给我今天的补给。", "哦哦真是对不起，我嘴欠，我该死，您就给我今天的补给吧。", "哦哦，谢谢长官，您可真是当将军的气度，比那个<b>独臂老流氓穆勒</b>不知道高到哪里去了！", "切，算我今天倒霉，我去街上搜刮点儿东西，不过可千万别遇到<b>穆勒</b>。", "又见面了，希望你今天也能做一名不让<b>本小姐</b>饿肚子的绅士。", "作为一个绅士，需要尽量满足女士的要求，请再给我一份儿食物。", "贪婪的吝啬鬼。要是在以前，我一定让我家里的<b>黑人仆人</b>痛扁你一顿。", "这还像一个绅士。", "哦，怎么又是你。贪婪吝啬的小士兵。|希望你今天能做一名不让<b>本小姐</b>饿肚子的绅士。", "再给我一份，算是补回上次的欠我的份。", "贪婪的吝啬鬼。要是在以前，我一定让我家里的<b>黑人仆人</b>痛扁你一顿。", "这还像一个绅士。", "菜鸟，听说了吗，敌人已经接近了。<color=#ff0000>我可不是废人，我要回到战争中！</color>|快给我份儿物资我要回去训练了！", "多谢，今天不跟你废话。<color=#ff0000>等到时候敌人来了，你可别吓尿裤子啊哈哈！</color>", "是不是苏珊那个八婆跟你说了什么，我天天看到她在说我的坏话。|还说我抢夺他孩子的食物，一派胡言！<color=#ff0000>我去教育教育她！</color>", "哦，我听说，战线就要压过来了，这简直太可怕了。|我家里这可怎么办啊……|我需要更多的食物，来度过这段艰难的时间。", "再给一些吧……|我家里很困难……", "哦，真是太感谢你了。希望你也能度过这段时间。", "<color=#ff0000>这战争真让人发疯！所有人都下地狱吧！</color>", "平安夜，团聚的日子，但我依然没有收到<b>我儿子</b>的书信，您能联系到我儿子吗……|或者给我一些食物让过个安稳节。", "无论如何，感谢您。", "战线迫近，饥寒交迫，我这个老太婆还能不能看到自己的<b>儿子</b>啊……", "您好军官。希望这次您能提供我一些食物，让我这个老太婆能度过平安夜……|顺便问下，您能联系到<b>我的儿子戈麦斯</b>了吗。", "无论如何，感谢您。", "<color=#ff0000>你们不能这么对一个老太婆！</color>", "嘿，菜鸟，快撤离这里，敌人刚刚突袭进城了！|北面的一个物资站已经被夷为平地了！", "你以为我是来捣乱的？没跟你开玩笑！<color=#ff0000>别在干你这卑微的工作了，快躲起来，炸弹就要来了！</color>", "你以为我是来捣乱的？没跟你开玩笑！<color=#ff0000>别在干你这卑微的工作了，快躲起来，炸弹就要来了！</color>", "战争，真是太残酷。一周前还好端端的小镇，现在变成了这个样子。|对了，前两天我问了一个来这里的士兵，他认识<b>我的儿子</b>。据说曾经和<b>穆勒</b>在一个部队。|现在<b>穆勒</b>也找不到了，真想问问他<b>我儿子</b>的情况。", "希望你们都能在这场该死的战争中生存下来。", "愿老天保佑我这个老太婆。", "哦，这可真是一场灾难。这场快速突袭席卷后，我也再也没看到<b>苏珊大婶</b>和她的孩子。|对了，听说<b>苏珊的孩子</b>是她在战区收养的孤儿。|为了这个孩子她一个独身女人也是拼上了一切，真是不容易啊。", "愿真主阿拉保佑你们。", "愿真主阿拉保佑你们。", "哦，这是我第一次切实经历战争。真是太恐怖了。|平安夜那天敌人坦克开过来的时候，我保护那个叫<b>爱丽丝<b/>的大小姐一起躲进了防空洞，别看她平时高傲冷酷，本身还是很善良的。|现在我们结伴住在一起，希望能够共同熬过这场战争。", "希望这场战争，早点结束。", "希望这场战争，早点结束。", };
    public int[] Yes = { 10003, 10003, 10004, 0, 0, 20002, 20003, 0, 0, 30002, 0, 0, 40002, 40003, 40005, 0, 0, 10008, 10011, 10011, 0, 0, 10013, 10016, 10016, 0, 0, 50002, 0, 0, 30005, 0, 0, 60003, 60003, 0, 0, 20007, 20009, 0, 0, 20013, 20015, 0, 0, 40007, 0, 0, 10018, 10019, 0, 0, 50005, 0, 0, 50008, 0, 0, 40010, 0, 0, 50011, 0, 0, 30008, 0, 0, 60006, 0, 0, };
    public int[] No = { 10002, 10005, 10005, 0, 0, 20004, 20004, 0, 0, 30003, 0, 0, 40004, 40004, 40004, 0, 0, 10009, 10009, 10010, 0, 0, 10014, 10015, 10015, 0, 0, 50003, 0, 0, 30006, 0, 0, 60002, 60004, 0, 0, 20008, 20008, 0, 0, 20014, 20014, 0, 0, 40008, 0, 0, 10018, 10020, 0, 0, 50006, 0, 0, 50009, 0, 0, 40011, 0, 0, 50012, 0, 0, 30009, 0, 0, 60007, 0, 0, };
    public int[] ID = { 10001, 10002, 10003, 10004, 10005, 20001, 20002, 20003, 20004, 30001, 30002, 30003, 40001, 40002, 40003, 40004, 40005, 10007, 10008, 10009, 10010, 10011, 10012, 10013, 10014, 10015, 10016, 50001, 50002, 50003, 30004, 30005, 30006, 60001, 60002, 60003, 60004, 20006, 20007, 20008, 20009, 20012, 20013, 20014, 20015, 40006, 40007, 40008, 10017, 10018, 10019, 10020, 50004, 50005, 50006, 50007, 50008, 50009, 40009, 40010, 40011, 50010, 50011, 50012, 30007, 30008, 30009, 60005, 60006, 60007};
    public int[] Emo = { 1, 3, 3, 1, 1, 2, 2, 1, 1, 1, 1, 2, 1, 2, 2, 2, 1, 1, 1, 3, 3, 2, 3, 1, 3, 2, 2, 1, 1, 2, 1, 1, 3, 1, 1, 1, 2, 2, 1, 3, 2, 2, 1, 3, 2, 1, 1, 2, 2, 2, 2, 3, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 2, 1, 2, 1, 1, 2, };
}